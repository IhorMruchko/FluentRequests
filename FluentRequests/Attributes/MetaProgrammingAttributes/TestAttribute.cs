using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace FluentRequests.Lib.Attributes.MetaProgrammingAttributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    internal class TestAttribute : CodeGenerationAttribute
    {
        protected string[] ValidTestCases { get; set; }

        protected string[] InvalidTestCases { get; set; }

        protected string[] InitParameters { get; set; }

        protected bool WithParameters => TestNumber != 0;

        protected uint TestNumber { get; set; }

        public TestAttribute(string directory = Constants.TestingDirectory,
                             string[] validTestCases = null,
                             string[] invalidTestCases = null,
                             string[] initParameters = null,
                             uint testNumber=0)
            : base(directory)
        {
            ValidTestCases = validTestCases;
            InvalidTestCases = invalidTestCases;
            InitParameters = initParameters;
            TestNumber = testNumber;
        }

        public override void Apply(MethodInfo method)
        {
            var methodName = method.Name;
            var parameters = string.Join(", ", method.GetParameters().Select(p => p.Name));
            var namespaces = string.Join("\r\n", method.GetParameters()
                .Select(p => $"using {p.ParameterType.Namespace};")
                .Concat(new string[]
                {
                    "using FluentRequests.Lib.Validation.Rules;"
                })
                .Distinct().OrderBy(n => n.Length));
            var className = method.DeclaringType.Name;
            var calling = $"{className}.{methodName}";
            
            var (testCaseAttributes, methodParameter, invokeParameter) = ValidTestCases == null 
                ? (string.Empty, string.Empty, "null")
                : ("\r\n\t" + string.Join("\r\n\t", ValidTestCases.Select(testCase => $"[TestCase({testCase})]")), "object value", "value");    
            
            var (invalidTestCaseAttributes, invalidMethodParameter, invalidInvokeParameter) = InvalidTestCases == null 
                ? (string.Empty, string.Empty, "null")
                : ("\r\n\t" + string.Join("\r\n\t", InvalidTestCases.Select(testCase => $"[TestCase({testCase})]")), "object value", "value");


            var initParameters = InitParameters == null ? string.Empty : string.Join(", ", InitParameters);
            var namingParameters = WithParameters == false || InitParameters == null ? string.Empty : "_" + string.Join("_", InitParameters);

            var filePath = Path.Combine(Directory, className + "Tests");
            if (System.IO.Directory.Exists(filePath) == false)
            {
                System.IO.Directory.CreateDirectory(filePath);
            }
            filePath = Path.Combine(filePath, methodName + (WithParameters ? TestNumber.ToString() : string.Empty) + "Test" + Constants.FileExtension);
            File.WriteAllText(filePath, string.Format(Constants.TestPattern,
                                                      namespaces,
                                                      className,
                                                      testCaseAttributes,
                                                      methodName,
                                                      methodParameter,
                                                      invokeParameter,
                                                      invalidTestCaseAttributes,
                                                      invalidMethodParameter,
                                                      invalidInvokeParameter,
                                                      initParameters,
                                                      namingParameters));
        }
    }
}

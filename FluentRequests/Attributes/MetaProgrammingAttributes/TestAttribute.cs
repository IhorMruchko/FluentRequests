using FluentRequests.Lib.Extensions;
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
            method.Decompose()
                  .Get(m => m.Name, out var methodName)
                  .Get(m => m.GetParameters().Select(p => p.Name), out var parameters)
                  .Get(m => string.Join("\r\n", m.GetParameters()
                                                      .Select(p => $"using {p.ParameterType.Namespace};")
                                                      .Concat(new string[] { "using FluentRequests.Lib.Validation.Rules;" })
                                                      .Distinct()
                                                      .OrderBy(n => n.Length)), out var namespaces)
                  .Get(m => m.DeclaringType.Name, out var className)
                  .Get(m => $"{m.DeclaringType.Name}.{m.Name}", out var calling);

            ValidTestCases.Decompose()
                .Get(cases => cases == null
                              ? string.Empty
                              : "\r\n\t" + string.Join("\r\n\t", cases.Select(testCase => $"[TestCase({testCase})]")), out var testCaseAttributes)
                .Get(cases => cases == null
                              ? string.Empty
                              : "object value", out var methodParameter)
                .Get(cases => cases == null
                              ? "null"
                              : "value", out var invokeParameter);

            InvalidTestCases.Decompose()
                .Get(cases => cases == null
                              ? string.Empty
                              : "\r\n\t" + string.Join("\r\n\t", cases.Select(testCase => $"[TestCase({testCase})]")), out var invalidTestCaseAttributes)
                .Get(cases => cases == null
                              ? string.Empty
                              : "object value", out var invalidMethodParameter)
                .Get(cases => cases == null
                              ? "null"
                              : "value", out var invalidInvokeParameter);

            InitParameters.Decompose()
                          .Get(@params => @params == null ? string.Empty : string.Join(", ", @params), out var initParameters)
                          .Get(@params => @params == null || WithParameters == false ? string.Empty : "_" + string.Join("_", @params), out var namingParameters);

            Directory.Decompose()
                     .Get(dir => Path.Combine(dir, className + "Tests"), out var testDirectory)
                     .Get(dir => Path.Combine(testDirectory, methodName + (WithParameters ? TestNumber.ToString() : string.Empty) + "Test" + Constants.FileExtension), out var filePath);

            testDirectory.CreateIfNotExists();
            
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

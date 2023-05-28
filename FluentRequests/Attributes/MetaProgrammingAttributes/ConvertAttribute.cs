using FluentRequests.Lib.Attributes.ParameterAttributes;
using FluentRequests.Lib.Extensions;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace FluentRequests.Lib.Attributes.MetaProgrammingAttributes
{
    [AttributeUsage(AttributeTargets.Method)]
    internal class ConvertAttribute : CodeGenerationAttribute
    {
        public ConvertAttribute(string directory = Constants.AttributesDirectory) 
            : base(directory)
        {
        }

        public override void Apply(MethodInfo method)
        {
            var methodName = method.Name;
            var notOptionalParameters = method.GetParameters().Where(p => p.IsOptional == false).ToArray();
            var constructorParameters = string.Join(", ", notOptionalParameters.Select(p => $"{p.Display()}"));
            var parameters = string.Join(", ", notOptionalParameters.Select(p => p.Name));
            var namespaces = string.Join("\r\n", notOptionalParameters
                .Select(p => $"using {p.ParameterType.Namespace};")
                .Concat(new string[]
                {
                    "using FluentRequests.Lib.Validation.Rules;"
                })
                .Distinct().OrderBy(n => n.Length));
            var className = method.DeclaringType.Name;
            var calling = $"{className}.{methodName}";

            var filePath = Path.Combine(Directory, className + "Attributes");
            if (System.IO.Directory.Exists(filePath) == false)
            {
                System.IO.Directory.CreateDirectory(filePath);
            }
            var validationfilePath = Path.Combine(filePath, methodName + "ValidateAttribute" + Constants.FileExtension);
            var constraintfilePath = Path.Combine(filePath, methodName + "ConstraintAttribute" + Constants.FileExtension);
            File.WriteAllText(validationfilePath, string.Format(Constants.Pattern,
                                                                namespaces,
                                                                className,
                                                                methodName,
                                                                constructorParameters,
                                                                calling,
                                                                parameters,
                                                                nameof(ValidateAttribute)));

            File.WriteAllText(constraintfilePath, string.Format(Constants.Pattern,
                                                               namespaces,
                                                               className,
                                                               methodName,
                                                               constructorParameters,
                                                               calling,
                                                               parameters,
                                                               nameof(ConstraintAttribute)));
        }
    }
}

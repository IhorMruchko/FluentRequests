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
            method.Decompose()
                  .Get(m => m.Name, out var methodName)
                  .Get(m => m.GetParameters().ToArray(), out var parameters)
                  .Get(m => m.DeclaringType.Name, out var className)
                  .Get(m => $"{m.DeclaringType.Name}.{m.Name}", out var calling);

            parameters.Decompose()
                      .Get(@params => string.Join(", ", @params.Select(p => $"{p.Display()}")), out var constructorParameters)
                      .Get(@params => string.Join(", ", @params.Select(p => p.Name)), out var methodParameters)
                      .Get(@params => string.Join("\r\n", parameters.Select(p => $"using {p.ParameterType.Namespace};")
                                                                         .Concat(new string[] { "using FluentRequests.Lib.Validation.Rules;" })
                                                                         .Distinct()
                                                                         .OrderBy(n => n.Length)), out var namespaces);

            Directory.Decompose()
                     .Get(dir => Path.Combine(dir, className + "Attributes"), out var initialFolder)
                     .Get(dir => Path.Combine(initialFolder, "ValidationAttributes"), out var validationAttributeFolder)
                     .Get(dir => Path.Combine(initialFolder, "ConstraintAttributes"), out var constraintAttributeFolder)
                     .Get(dir => Path.Combine(validationAttributeFolder, methodName + "ValidateAttribute" + Constants.FileExtension), out var validateFilePath)
                     .Get(dir => Path.Combine(constraintAttributeFolder, methodName + "ConstraintAttribute" + Constants.FileExtension), out var constraintFilePath);

            initialFolder.CreateIfNotExists();
            validationAttributeFolder.CreateIfNotExists();
            constraintAttributeFolder.CreateIfNotExists();

            File.WriteAllText(validateFilePath, string.Format(Constants.Pattern,
                                                              namespaces,
                                                              className,
                                                              methodName,
                                                              constructorParameters,
                                                              calling,
                                                              methodParameters,
                                                              nameof(ValidateAttribute),
                                                              "Validation"));

            File.WriteAllText(constraintFilePath, string.Format(Constants.Pattern,
                                                                namespaces,
                                                                className,
                                                                methodName,
                                                                constructorParameters,
                                                                calling,
                                                                methodParameters,
                                                                nameof(ConstraintAttribute),
                                                                "Constraint"));
        }
    }
}

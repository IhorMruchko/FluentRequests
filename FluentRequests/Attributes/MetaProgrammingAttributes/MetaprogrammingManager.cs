using FluentRequests.Lib.Validation.Base;
using FluentRequests.Lib.Validation.Error;
using FluentRequests.Lib.Validation.Rules;
using System;
using System.Linq;
using System.Reflection;

namespace FluentRequests.Lib.Attributes.MetaProgrammingAttributes
{
    internal static class MetaprogrammingManager
    {
        private static readonly Rule<MethodInfo> _methodRules =
           MethodInfoRules.ContainsAttribute<ConvertAttribute>()
                          .InitOperations()
                          .Or(MethodInfoRules.ContainsAttribute<TestAttribute>())
            .EndInit()
            .InitOperations()
                         .And(MethodInfoRules.IsPublic(InformingLevel.Warning).InitOperations()
                         .And(MethodInfoRules.IsStatic(InformingLevel.Warning))
                         .And(MethodInfoRules.IsAbstract(InformingLevel.Warning).Not())
                         .And(MethodInfoRules.HasReturningType(typeof(RuleBase), InformingLevel.Warning)).EndInit())
            .EndInit();

        public static void Generate()
        {
            var markedMethods = AppDomain.CurrentDomain.GetAssemblies()
               .SelectMany(a => a.GetTypes())
               .SelectMany(t => t.GetMethods())
               .Where(m => _methodRules.Validate(m))
               .ToArray();

            CreateCode(markedMethods);
        }

        private static void CreateCode(MethodInfo[] markedMethods)
        {
            foreach (var method in markedMethods)
            {
                foreach (var attribute in method.GetCustomAttributes<MetaProgrammingAttribute>())
                {
                    attribute.Apply(method);
                }
            }
        }
    }
}

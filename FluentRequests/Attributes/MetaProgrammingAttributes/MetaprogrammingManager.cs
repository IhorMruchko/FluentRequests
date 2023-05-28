using FluentRequests.Lib.Validation.Base;
using FluentRequests.Lib.Validation.Error;
using FluentRequests.Lib.Validation.Rules;
using System.Linq;
using System.Reflection;

namespace FluentRequests.Lib.Attributes.MetaProgrammingAttributes
{
    public static class MetaprogrammingManager
    {
        private static readonly Rule<MethodInfo> _methodRules =
           MethodInfoRules.ContainsAttribute<ConvertAttribute>()
               .Or(MethodInfoRules.ContainsAttribute<TestAttribute>())
               .Or(MethodInfoRules.ContainsAttribute<DetestAttribute>())
               .Or(MethodInfoRules.ContainsAttribute<ConvertAttribute>())
            .And(MethodInfoRules.IsPublic(InformingLevels.Warn)
               .And(MethodInfoRules.IsStatic(InformingLevel.Warning))
               .And(MethodInfoRules.IsAbstract(InformingLevel.Warning).Not())
               .And(MethodInfoRules.HasReturningType(typeof(RuleBase), new Warning())));
        
        public static void Generate()
        {
            var markedMethods = Assembly.GetAssembly(typeof(MetaprogrammingManager)).GetTypes()
               .SelectMany(t => t.GetMethods()
               .Where(m => _methodRules.Validate(m)))
               .ToArray();

            CreateCode(markedMethods);
        }

        private static void CreateCode(MethodInfo[] markedMethods)
        {
            foreach (var method in markedMethods)
            {
                foreach(var attribute in method.GetCustomAttributes<MetaProgrammingAttribute>())
                {
                    attribute.Apply(method);
                }
            }
        }
    }
}

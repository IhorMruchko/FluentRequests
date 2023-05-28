using System;
using System.Reflection;
using FluentRequests.Lib.Validation.Base;
using FluentRequests.Lib.Validation.Error;

namespace FluentRequests.Lib.Validation.Rules
{
    public static class MethodInfoRules
    {
        public static Rule<MethodInfo> IsStatic(Informing state = null)
            => new Rule<MethodInfo>(m => m.IsStatic, m => string.Format(Constants.Messages.METHOD_IS_NOT_STATIC, m.Name), state);
        
        public static Rule<MethodInfo> IsPublic(Informing state = null)
            => new Rule<MethodInfo>(m => m.IsPublic, m => m.Name + " must be public!", state);

        public static Rule<MethodInfo> IsAbstract(Informing state = null)
            => new Rule<MethodInfo>(m => m.IsAbstract, m => m.Name + " must be abstract!", state: state);

        public static NotRule<MethodInfo> ContainsAttribute<TAttribute>(Informing state = null)
            where TAttribute : Attribute
            => new NotRule<MethodInfo>(m => m.GetCustomAttribute<TAttribute>() == null, state: state);

        public static Rule<MethodInfo> HasReturningType(Type expected, Informing state = null)
            => new Rule<MethodInfo>(m => m.ReturnType.IsSubclassOf(expected), 
                m => string.Format(Constants.Messages.METHOD_HAS_DIFFERENT_RETURNING_TYPE,
                                               m.Name,
                                               expected.Name,
                                               m.ReturnType.Name), 
                state);
    }
}

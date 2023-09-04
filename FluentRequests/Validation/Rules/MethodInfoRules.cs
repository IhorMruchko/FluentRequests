using System;
using System.Reflection;
using FluentRequests.Lib.Validation.Base;
using FluentRequests.Lib.Validation.Error;

namespace FluentRequests.Lib.Validation.Rules
{
    public static class MethodInfoRules
    {
        public static Rule<MethodInfo> IsStatic(InformingLevel level = InformingLevel.Ignore)
            => Rule<MethodInfo>.BeginInit()
                               .FromMethod(methodInfo => methodInfo.IsStatic)
                               .OnLevel(level)
                               .WithPropertySelector(methodInfo => $"Method '{methodInfo.Name}'")
                               .WithConstraint("Method must be static")
                               .EndInit();
        
        public static Rule<MethodInfo> IsPublic(InformingLevel level = InformingLevel.Ignore)
            => Rule<MethodInfo>.BeginInit()
                               .FromMethod(methodInfo => methodInfo.IsPublic)
                               .OnLevel(level)
                               .WithPropertySelector(methodInfo => $"Method '{methodInfo.Name}'")
                               .WithConstraint("Method must be public")
                               .EndInit();

        public static Rule<MethodInfo> IsAbstract(InformingLevel level = InformingLevel.Ignore)
            => Rule<MethodInfo>.BeginInit()
                               .FromMethod(methodInfo => methodInfo.IsAbstract)
                               .OnLevel(level)
                               .WithPropertySelector(methodInfo => $"Method '{methodInfo.Name}'")
                               .WithConstraint("Method must be abstract")
                               .EndInit();


        public static Rule<MethodInfo> ContainsAttribute<TAttribute>(InformingLevel level = InformingLevel.Ignore)
            where TAttribute : Attribute
            => Rule<MethodInfo>.BeginInit()
                               .FromMethod(m => m.GetCustomAttribute<TAttribute>() != null)
                               .OnLevel(level)
                               .WithConstraint($"Method must contains {typeof(TAttribute).Name}.")
                               .WithPropertySelector(m => $"Method '{m.Name}'")
                               .EndInit();

        public static Rule<MethodInfo> HasReturningType(Type expected, InformingLevel level = InformingLevel.Ignore)
            => Rule<MethodInfo>.BeginInit()
                               .FromMethod(m => m.ReturnType == expected || m.ReturnType.IsSubclassOf(expected))
                               .OnLevel(level)
                               .WithPropertySelector(m => $"Method '{m.Name}'")
                               .WithConstraint($"Method should have returning type of {expected.Name}")
                               .EndInit();
    }
}

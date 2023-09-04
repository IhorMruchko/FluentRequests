using FluentRequests.Lib.Callable.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentRequests.Lib.Extensions
{
    public static class ArgumentsExtension
    {
        public static TValue ValueOf<TValue>(this List<ArgumentBase> arguments, string argumentName, TValue defaultResult = default)
        {
            foreach(var argument in arguments)
            {
                if (argument is OptionalArgument<TValue> optionalArgument
                    && optionalArgument.Name.Equals(argumentName, StringComparison.InvariantCultureIgnoreCase))
                    return optionalArgument.TryGetValue(out var result) ? result : optionalArgument.DefaultValue;

                if (argument is RequiredArgument<TValue> requiredArgument
                    && requiredArgument.Name.Equals(argumentName, StringComparison.InvariantCultureIgnoreCase))
                    return requiredArgument.TryGetValue(out var result) ? result : defaultResult;
            }
            
            return default;
        }

        public static object ValueOf(this List<ArgumentBase> arguments, string argumentName, Type type)
        {
            foreach (var argument in arguments)
            {
                if (argument.GetType().GenericTypeArguments.First() == type
                    && argument.Name.Equals(argumentName, StringComparison.InvariantCultureIgnoreCase))
                    return argument.CurrentValue;
            }
            return null;
        }
    }
}

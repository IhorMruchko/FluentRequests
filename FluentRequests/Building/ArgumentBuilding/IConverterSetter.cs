using FluentRequests.Lib.Callable.Arguments;
using System;

namespace FluentRequests.Lib.Building.ArgumentBuilding
{
    public interface IConverterSetter<TArgumentObject, TArgument> : IAfterHelpSetter
        where TArgumentObject : Argument<TArgument>
    {
        IRuleBaseSetter<TArgumentObject, TArgument> WithConverter(Converter<string, TArgument> converter);

        IRuleBaseSetter<TArgumentObject, TArgument> UseDefaultConverter();
    }
}

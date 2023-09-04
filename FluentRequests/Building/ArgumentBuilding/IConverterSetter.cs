using FluentRequests.Lib.Callable.Arguments;
using System;

namespace FluentRequests.Lib.Building.ArgumentBuilding
{
    public interface IConverterSetter<TArgumentBeforeEnd, TArgument> : IAfterHelpSetter
    {
        IRuleBaseSetter<TArgumentBeforeEnd, TArgument> WithConverter(Converter<string, TArgument> converter);

        IRuleBaseSetter<TArgumentBeforeEnd, TArgument> UseDefaultConverter();
    }
}

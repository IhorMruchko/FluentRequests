using FluentRequests.Lib.Building.ArgumentBuilding;
using FluentRequests.Lib.Callable.Arguments;
using System;

namespace FluentRequests.Lib.Building.OverloadBuilding
{
    public interface IParametersSetter : IAfterHelpSetter, IBodySetter
    {
        IParametersSetter WithRequired<TArgument>(RequiredArgument<TArgument> argument);
        
        IParametersSetter WithRequired<TArgument>(Func<IArgumentNameSetter<IArgumentCreator<RequiredArgument<TArgument>, TArgument>, TArgument>, 
            RequiredArgument<TArgument>> argument);

        IParametersSetter WithOptional<TArgument>(OptionalArgument<TArgument> argument);

        IParametersSetter WithOptional<TArgument>(Func<IArgumentNameSetter<IDefaultValueSetter<TArgument>, TArgument>, 
            OptionalArgument<TArgument>> argument);
    }
}
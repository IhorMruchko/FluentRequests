using FluentRequests.Lib.Building.ArgumentBuilding;

namespace FluentRequests.Lib.Callable.Arguments
{
    public interface IDefaultValueSetter<TArgument>
    {
         IArgumentCreator<OptionalArgument<TArgument>, TArgument> WithDefaultValue(TArgument defaultValue);
    }
}
using FluentRequests.Lib.Callable.Arguments;

namespace FluentRequests.Lib.Building.ArgumentBuilding
{
    public interface IArgumentNameSetter<TArgumentObject, TArgument>
        where TArgumentObject : Argument<TArgument>
    {
        IHelpSetter<IConverterSetter<TArgumentObject, TArgument>> WithName(string name);
    }
}

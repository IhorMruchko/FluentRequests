using FluentRequests.Lib.Callable.Arguments;

namespace FluentRequests.Lib.Building.ArgumentBuilding
{
    public interface IArgumentFinalizer<TArgumentObject, TArgument>
        where TArgumentObject : Argument<TArgument>
    {
        TArgumentObject EndInit();
    }
}

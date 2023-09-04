using FluentRequests.Lib.Callable.Arguments;

namespace FluentRequests.Lib.Building.ArgumentBuilding
{
    public interface IArgumentFinalizer<TArgumentBeforeEnd, TArgument>
    {
        TArgumentBeforeEnd Instatniate();
    }
}

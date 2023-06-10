using FluentRequests.Lib.Callable.Arguments;

namespace FluentRequests.Lib.Building.ArgumentBuilding
{
    public interface IRuleBaseSetter<TArgumentBeforeEnd, TArgument> : 
        IConstraintSetter<TArgumentBeforeEnd, TArgument>, 
        IValidationSetter<TArgumentBeforeEnd, TArgument>
    {
    }
}

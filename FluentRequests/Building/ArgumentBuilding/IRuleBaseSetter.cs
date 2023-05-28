using FluentRequests.Lib.Callable.Arguments;

namespace FluentRequests.Lib.Building.ArgumentBuilding
{
    public interface IRuleBaseSetter<TArgumentObject, TArgument> : 
        IConstraintSetter<TArgumentObject, TArgument>, 
        IValidationSetter<TArgumentObject, TArgument>
        where TArgumentObject : Argument<TArgument>
    {
    }
}

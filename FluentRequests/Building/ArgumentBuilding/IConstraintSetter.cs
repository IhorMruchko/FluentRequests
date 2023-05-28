using FluentRequests.Lib.Callable.Arguments;
using FluentRequests.Lib.Validation.Base;

namespace FluentRequests.Lib.Building.ArgumentBuilding
{
    public interface IConstraintSetter<TArgumentObject, TArgument> : 
        IArgumentFinalizer<TArgumentObject, TArgument>
        where TArgumentObject : Argument<TArgument>
    {
        IValidationOnlySetter<TArgumentObject, TArgument> WithConstraint(Rule<TArgument> constraint);
    }
}
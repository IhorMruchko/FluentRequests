using FluentRequests.Lib.Validation.Base;

namespace FluentRequests.Lib.Building.ArgumentBuilding
{
    public interface IConstraintSetter<TArgumentBeforeEnd, TArgument> : IArgumentFinalizer<TArgumentBeforeEnd, TArgument>
    {
        IValidationOnlySetter<TArgumentBeforeEnd, TArgument> WithConstraint(Rule<TArgument> constraint);
    }
}
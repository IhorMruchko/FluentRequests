using FluentRequests.Lib.Validation.Base;

namespace FluentRequests.Lib.Building.ArgumentBuilding
{
    public interface IConstraintOnlySetter<TArgumentBeforeEnd, TArgument> : IArgumentFinalizer<TArgumentBeforeEnd, TArgument>
    {
        IArgumentFinalizer<TArgumentBeforeEnd, TArgument> WithConstraint(Rule<TArgument> validation);
    }
}

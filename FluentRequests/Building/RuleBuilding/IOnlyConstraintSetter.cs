namespace FluentRequests.Lib.Building.RuleBuilding
{
    public interface IOnlyConstraintSetter<TValue>
    {
        IRuleOperationSetter<TValue> WithConstraint(string message);
    }
}
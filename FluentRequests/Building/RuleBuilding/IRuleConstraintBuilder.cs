namespace FluentRequests.Lib.Building.RuleBuilding
{
    public interface IRuleConstraintBuilder<TValue> : 
        IRuleConstraintSetter<TValue>,
        IPropertySelectorSetter<TValue>
    {
    }
}

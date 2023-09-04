using System;

namespace FluentRequests.Lib.Building.RuleBuilding
{
    public interface IRuleConstraintSetter<TValue>
    {
        IOnlyPropertySelectorSetter<TValue> WithConstraint(string message);
    }
}
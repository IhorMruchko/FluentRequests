using System;

namespace FluentRequests.Lib.Building.RuleBuilding
{
    public interface IPropertySelectorSetter<TValue>
    {
        IOnlyConstraintSetter<TValue> WithPropertySelector(Func<TValue, string> selector);
    }
}
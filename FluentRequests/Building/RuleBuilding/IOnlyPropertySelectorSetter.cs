using System;

namespace FluentRequests.Lib.Building.RuleBuilding
{
    public interface IOnlyPropertySelectorSetter<TValue>
    {
        IRuleOperationSetter<TValue> WithPropertySelector(Func<TValue, string> selector);
    }
}
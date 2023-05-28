using System;

namespace FluentRequests.Lib.Building.RuleBuilding
{
    public interface IRuleMessageSetter<TValue> : IRuleOperationSetter<TValue>
    {
        IRuleOperationSetter<TValue> WithMessage(string message);

        IRuleOperationSetter<TValue> WithMessage(Func<TValue, string> messageBuilder);
    }
}
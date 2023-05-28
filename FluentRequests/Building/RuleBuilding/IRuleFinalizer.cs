using FluentRequests.Lib.Validation.Base;

namespace FluentRequests.Lib.Building.RuleBuilding
{
    public interface IRuleFinalizer<TValue>
    {
        Rule<TValue> EndInit();
    }
}
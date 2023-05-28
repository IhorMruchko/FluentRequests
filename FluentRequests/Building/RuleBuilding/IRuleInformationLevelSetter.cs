using FluentRequests.Lib.Validation.Error;

namespace FluentRequests.Lib.Building.RuleBuilding
{
    public interface IRuleInformationLevelSetter<TValue>
    {
        IRuleMessageSetter<TValue> OnDefaultLevel();

        IRuleMessageSetter<TValue> OnLevel(Informing state);
    }
}
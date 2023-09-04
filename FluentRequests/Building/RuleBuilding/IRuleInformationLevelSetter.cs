using FluentRequests.Lib.Validation.Error;

namespace FluentRequests.Lib.Building.RuleBuilding
{
    public interface IRuleInformationLevelSetter<TValue>
    {
        IRuleOperationSetter<TValue> OnDefaultLevel();

        IRuleConstraintBuilder<TValue> OnLevel(Informing level);

        IRuleConstraintBuilder<TValue> OnLevel(InformingLevel level);
    }
}
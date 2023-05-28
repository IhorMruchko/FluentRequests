namespace FluentRequests.Lib.Building.RuleBuilding
{
    public interface IRuleEditer<TValue> : IRuleInformationLevelSetter<TValue>,
                                           IRuleOperationSetter<TValue>,
                                           IRuleMessageSetter<TValue>
    {
    }
}

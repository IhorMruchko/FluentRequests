using System;

namespace FluentRequests.Lib.Building.RuleBuilding
{
    public interface IRuleBodySetter<TArgument>
    {
        IRuleInformationLevelSetter<TArgument> FromMethod(Func<TArgument, bool> method);
    }
}
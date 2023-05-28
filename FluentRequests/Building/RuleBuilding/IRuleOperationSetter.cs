using FluentRequests.Lib.Validation.Base;
using System;

namespace FluentRequests.Lib.Building.RuleBuilding
{
    public interface IRuleOperationSetter<TValue> : IRuleFinalizer<TValue>
    {
        IRuleOperationSetter<TValue> And(Rule<TValue> another);
        
        IRuleOperationSetter<TValue> And(Func<IRuleBodySetter<TValue>, Rule<TValue>> anotherBuilding);

        IRuleOperationSetter<TValue> Or(Rule<TValue> another);

        IRuleOperationSetter<TValue> Or(Func<IRuleBodySetter<TValue>, Rule<TValue>> anotherBuilding);

        IRuleOperationSetter<TValue> Xor(Rule<TValue> another);

        IRuleOperationSetter<TValue> Xor(Func<IRuleBodySetter<TValue>, Rule<TValue>> anotherBuilding);

        IRuleOperationSetter<TValue> Eq(Rule<TValue> another);

        IRuleOperationSetter<TValue> Eq(Func<IRuleBodySetter<TValue>, Rule<TValue>> anotherBuilding);

        IRuleOperationSetter<TValue> Implication(Rule<TValue> another);

        IRuleOperationSetter<TValue> Implication(Func<IRuleBodySetter<TValue>, Rule<TValue>> anotherBuilding);

        IRuleOperationSetter<TValue> Not();
    }
}
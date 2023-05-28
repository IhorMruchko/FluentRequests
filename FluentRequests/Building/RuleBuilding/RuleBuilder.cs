using FluentRequests.Lib.Validation.Base;
using FluentRequests.Lib.Validation.Error;
using System;

namespace FluentRequests.Lib.Building.RuleBuilding
{
    public class RuleBuilder<TValue> : IRuleBodySetter<TValue>,
                                       IRuleInformationLevelSetter<TValue>,
                                       IRuleMessageSetter<TValue>,
                                       IRuleOperationSetter<TValue>,
                                       IRuleFinalizer<TValue>,
                                       IRuleEditer<TValue>
    {
        private Rule<TValue> _rule = new Rule<TValue>(null, null, null);
        
        public RuleBuilder() { }

        public RuleBuilder(Rule<TValue> rule)
        {
            _rule = rule;
        }

        public IRuleInformationLevelSetter<TValue> FromMethod(Func<TValue, bool> method)
        {
            _rule.Constraint = method;
            return this;
        }

        public IRuleMessageSetter<TValue> OnDefaultLevel()
        {
            //_rule.InformingLevel = new Ignore();
            return this;
        }

        public IRuleMessageSetter<TValue> OnLevel(Informing state)
        {
            //_rule.InformingLevel = state ?? new Ignore();
            return this;
        }

        public IRuleMessageSetter<TValue> OnLevel(InformingLevel level)
            => OnLevel(InformingLevels.GetLevel(level));

        public IRuleOperationSetter<TValue> WithMessage(string message)
            => WithMessage(value => message);

        public IRuleOperationSetter<TValue> WithMessage(Func<TValue, string> messageBuilder)
        {
            _rule.Message = messageBuilder;
            return this;
        }

        public IRuleOperationSetter<TValue> And(Rule<TValue> another)
        {
            _rule = new AndRule<TValue>(_rule, another);
            return this;
        }

        public IRuleOperationSetter<TValue> And(Func<IRuleBodySetter<TValue>, Rule<TValue>> anotherBuilding)
            => And(anotherBuilding(new RuleBuilder<TValue>()));

        public IRuleOperationSetter<TValue> Or(Rule<TValue> another)
        {
            _rule = new OrRule<TValue>(_rule, another);
            return this;
        }

        public IRuleOperationSetter<TValue> Or(Func<IRuleBodySetter<TValue>, Rule<TValue>> anotherBuilding)
            => Or(anotherBuilding(new RuleBuilder<TValue>()));

        public IRuleOperationSetter<TValue> Eq(Rule<TValue> another)
        {
            throw new NotImplementedException();
        }

        public IRuleOperationSetter<TValue> Eq(Func<IRuleBodySetter<TValue>, Rule<TValue>> anotherBuilding)
        {
            throw new NotImplementedException();
        }

        public IRuleOperationSetter<TValue> Xor(Rule<TValue> another)
        {
            throw new NotImplementedException();
        }

        public IRuleOperationSetter<TValue> Xor(Func<IRuleBodySetter<TValue>, Rule<TValue>> anotherBuilding)
        {
            throw new NotImplementedException();
        }

        public IRuleOperationSetter<TValue> Implication(Rule<TValue> another)
        {
            throw new NotImplementedException();
        }

        public IRuleOperationSetter<TValue> Implication(Func<IRuleBodySetter<TValue>, Rule<TValue>> anotherBuilding)
        {
            throw new NotImplementedException();
        }

        public IRuleOperationSetter<TValue> Not()
        {
            _rule = _rule.Not();
            return this;
        }

        public Rule<TValue> EndInit()
        {
            return _rule;
        }
    }
}

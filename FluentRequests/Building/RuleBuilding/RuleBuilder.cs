using FluentRequests.Lib.Validation.Base;
using FluentRequests.Lib.Validation.Error;
using System;

namespace FluentRequests.Lib.Building.RuleBuilding
{
    public class RuleBuilder<TValue> : IRuleBodySetter<TValue>,
                                       IRuleInformationLevelSetter<TValue>,
                                       IRuleConstraintSetter<TValue>,
                                       IPropertySelectorSetter<TValue>,
                                       IOnlyConstraintSetter<TValue>,
                                       IOnlyPropertySelectorSetter<TValue>,
                                       IRuleOperationSetter<TValue>,
                                       IRuleFinalizer<TValue>,
                                       IRuleConstraintBuilder<TValue>
    {
        private Rule<TValue> _rule;

        public RuleBuilder(Rule<TValue> rule = null)
        {
            _rule = rule ?? new UnaryRule<TValue>();
        }

        public IRuleInformationLevelSetter<TValue> FromMethod(Func<TValue, bool> method)
        {
            _rule.Constraint = method;
            return this;
        }

        public IRuleOperationSetter<TValue> OnDefaultLevel()
        {
            _rule.Level = new Ignore();
            return this;
        }

        public IRuleConstraintBuilder<TValue> OnLevel(Informing level)
        {
            _rule.Level = level ?? InformingLevels.Ignore;
            return this;
        }

        public IRuleConstraintBuilder<TValue> OnLevel(InformingLevel level)
        {
            _rule.Level = InformingLevels.GetLevel(level) ?? new Ignore();
            return this;
        }

        public IOnlyPropertySelectorSetter<TValue> WithConstraint(string message)
        {
            _rule.ConstraintDescription = message;
            return this;
        }

        public IOnlyConstraintSetter<TValue> WithPropertySelector(Func<TValue, string> selector)
        {
            _rule.PropertiesSelector = selector;
            return this;
        }

        IRuleOperationSetter<TValue> IOnlyPropertySelectorSetter<TValue>.WithPropertySelector(Func<TValue, string> selector)
        {
            _rule.PropertiesSelector = selector;
            return this;
        }

        IRuleOperationSetter<TValue> IOnlyConstraintSetter<TValue>.WithConstraint(string message)
        {
            _rule.ConstraintDescription = message;
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

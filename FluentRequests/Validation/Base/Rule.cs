using FluentRequests.Lib.Building.RuleBuilding;
using FluentRequests.Lib.Validation.Error;
using System;

namespace FluentRequests.Lib.Validation.Base
{
    public abstract class Rule<TValue> : RuleBase
    {
        internal Func<TValue, bool> Constraint { get; set; }

        internal Informing Level { get; set; } = new Ignore();

        internal Func<TValue, string> PropertiesSelector { get; set; }

        internal string ConstraintDescription { get; set; }

        protected virtual string ConstraintPattern { get; } = "is not fit constraint";

        public static IRuleBodySetter<TValue> BeginInit()
            => new RuleBuilder<TValue>();

        public IRuleOperationSetter<TValue> InitOperations()
            => new RuleBuilder<TValue>(this);

        public override void DisplayMessage(object value)
        {
            if (PreviousResult == true)
                return;

            Level.OnError(GetMessage(value));
        }

        public override bool ValidateWithError(object value)
        {
            if (Validate(value))
                return true;

            DisplayMessage(value);
            return false;
        }

        public override string GetMessage(object value)
            => PropertiesSelector is null || ConstraintDescription is null
            ? $"Invalid value{value}"
            : value is TValue val
            ? $"{PropertiesSelector(val)} {ConstraintPattern} `{ConstraintDescription}`."
            : $"{value.GetType().Name} is not equal to {typeof(TValue)}";

        internal abstract Rule<TValue> Not();

        protected bool ValidateType(object value, out TValue typedValue)
        {
            typedValue = default;
            if (value is TValue val == false)
            {
                Level.OnError($"{value.GetType().Name} is not equal to {typeof(TValue)}");
                return false;
            }
            typedValue = val;
            return true;
        }
    }
}

using FluentRequests.Lib.Validation.Base;
using System;

namespace FluentRequests.Lib.Callable.Arguments
{
    public abstract class Argument<TArgument> : ArgumentBase
    {
        public Converter<string, TArgument> Converter { get; internal set; }

        public bool TryGetValue(out TArgument value)
        {
            value = default;

            if (Value is null)
                return false;

            try
            {
                value = (TArgument)Value;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public override bool TryParse(string value)
        {
            try
            {
                Value = Converter.Invoke(value);
                return true;
            }
            catch
            { 
                return false; 
            }
        }

        public override bool FitContraint() 
            => Constraint?.Validate(Value) ?? true;

        public override bool Validate() 
            => Validation?.Validate(Value) ?? true;

        internal override void SetConstraint(object constraint) 
            => Constraint = constraint as RuleBase;

        internal override void SetConverter(object converter) 
            => Converter = converter as Converter<string, TArgument>;

        internal override void SetValidator(object validator)
            => Validation = validator as RuleBase;
    }
}

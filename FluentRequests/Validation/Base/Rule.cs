using FluentRequests.Lib.Validation.Error;
using System;

namespace FluentRequests.Lib.Validation.Base
{
    public class Rule<TValue> : RuleBase
    {
        internal Func<TValue, bool> Constraint { get; set; }

        internal Informing State { get; set; }

        internal Func<TValue, string> Message { get; set; }        

        public Rule(Func<TValue, bool> constraint, Func<TValue, string> message = null, Informing state = null)
        { 
            Constraint = constraint;
            State = state ?? new Ignore();
            Message = message;
        }

        public override bool Validate(object value)
        {
            if (value is TValue val == false)
            {
                State.OnError($"{value.GetType().Name} is not equal to {typeof(TValue)}");
                return false;
            }
            
            if (Constraint(val)) return true;

            State.OnError(Message?.Invoke(val));
            return false;
        }

        public virtual Rule<TValue> And(Rule<TValue> another, Func<TValue, string> message = null, Informing state = null)
            => new AndRule<TValue>(this, another, message, state);

        public virtual Rule<TValue> Or(Rule<TValue> another, Func<TValue, string> message = null, Informing state = null) 
            => new OrRule<TValue>(this, another, message, state);

        public virtual Rule<TValue> Xor(Rule<TValue> another, Func<TValue, string> message = null, Informing state = null)
            => new XorRule<TValue>(this, another, message, state);

        public virtual Rule<TValue> Not(Func<TValue, string> message = null, Informing state = null) 
            => new NotRule<TValue>(this, message, state);

        public static implicit operator Rule<TValue>(Func<TValue, bool> constraint)
            => new Rule<TValue>(constraint);
    }
}

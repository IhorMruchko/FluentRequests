using FluentRequests.Lib.Validation.Error;
using System;

namespace FluentRequests.Lib.Validation.Base
{
    public class NotRule<TValue> : Rule<TValue>
    {
        public NotRule(Rule<TValue> first, Func<TValue, string> message = null, ValidationState state = null)
            : base((value) => first.Validate(value) == false, message, state ?? first.State)
        {
        }

        public NotRule(Func<TValue, bool> constraint, Func<TValue, string> message = null, ValidationState state = null)
           : base((value) => constraint(value) == false, message, state)
        {
        }

        public override Rule<TValue> Not(Func<TValue, string> message = null, ValidationState state = null)
        {
            return new Rule<TValue>(value => Constraint(value) == true, message, state);
        }
    }
}
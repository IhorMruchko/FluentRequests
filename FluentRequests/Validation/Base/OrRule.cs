using FluentRequests.Lib.Validation.Error;
using System;

namespace FluentRequests.Lib.Validation.Base
{
    internal class OrRule<TValue> : Rule<TValue>
    {
        public OrRule(Rule<TValue> first, Rule<TValue> second, Func<TValue, string> message = null, ValidationState state = null)
            : base((value) => first.Validate(value) || second.Validate(value), message, state)
        {
        }
    }
}
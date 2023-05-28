using FluentRequests.Lib.Validation.Error;
using System;

namespace FluentRequests.Lib.Validation.Base
{
    internal class AndRule<TValue> : Rule<TValue>
    {        
        public AndRule(Rule<TValue> first, Rule<TValue> second, Func<TValue, string> message = null, ValidationState state = null) 
            : base((value) => first.Validate(value) && second.Validate(value), message, state)
        {
        }
    }
}
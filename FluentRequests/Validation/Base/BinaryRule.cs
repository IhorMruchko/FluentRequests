using FluentRequests.Lib.Validation.Error;
using System;

namespace FluentRequests.Lib.Validation.Base
{
    public abstract class BinaryRule<TValue> : RuleBase
    {
        protected Rule<TValue> First { get; set; }

        protected Rule<TValue> Second { get; set; }

        public BinaryRule(Rule<TValue> first, Rule<TValue> second, ValidationState state=null)
        {
            First = first;
            Second = second;
        }

        protected abstract Func<object, bool> EvaluateConstraint();
    }
}

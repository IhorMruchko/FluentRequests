using FluentRequests.Lib.Validation.Base;
using System;

namespace FluentRequests.Lib.Attributes.ParameterAttributes
{
    [AttributeUsage(AttributeTargets.Parameter)]
    public abstract class ParameterAttribute : Attribute
    {
        public RuleBase Constraint { get; protected set; }
    }
}

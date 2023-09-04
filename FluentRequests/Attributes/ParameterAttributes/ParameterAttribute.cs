using FluentRequests.Lib.Validation.Base;
using System;

namespace FluentRequests.Lib.Attributes.ParameterAttributes
{
    [AttributeUsage(AttributeTargets.Parameter)]
    public class ParameterAttribute : Attribute
    {
        public RuleBase Rule { get; protected set; }
    }
}

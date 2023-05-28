using FluentRequests.Lib.Validation.Base;
using System;

namespace FluentRequests.Lib.Attributes.ParameterAttributes
{
    [AttributeUsage(AttributeTargets.Parameter)]
    public abstract class ConstraintAttribute : ParameterAttribute
    {
    }
}

using FluentRequests.Lib.Validation.Base;
using System;
using System.Data;

namespace FluentRequests.Lib.Callable.Arguments
{
    public abstract class Argument<TArgument> : ArgumentBase
    {
        public Converter<string, TArgument> Converter { get; internal set; }

        public Rule<TArgument> Validation { get; internal set; }

        public Rule<TArgument> Constraint { get; internal set; }
    }
}

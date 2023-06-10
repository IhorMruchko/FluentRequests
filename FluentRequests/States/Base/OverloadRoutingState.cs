using FluentRequests.Lib.Callable.CallableOverload;
using FluentRequests.Lib.Validation.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentRequests.Lib.States.Base
{
    internal abstract class OverloadRoutingState : RoutingState
    {
        protected readonly Rule<string> IsRequiredParameter
          = Rule<string>.BeginInit()
                        .FromMethod(a => a.StartsWith("#"))
                        .OnDefaultLevel()
                        .Or(rb => rb.FromMethod(a => a.StartsWith("--"))
                                    .OnDefaultLevel()
                                    .EndInit())
                        .Or(rb => rb.FromMethod(a => a.Contains("="))
                                    .OnDefaultLevel()
                                    .EndInit())
                        .Not()
                        .EndInit();
        protected Overload OverloadSource { get; set; }

        public OverloadRoutingState(IEnumerable<string> arguments): base(arguments) { }

        public override RoutingState SetSource(IRoutingSource source)
        {
            base.SetSource(source);
            if (source is Overload overload == false)
                throw new ArgumentException($"Argument of the {nameof(SetSource)} must be of type {typeof(Overload).Name}");

            OverloadSource = overload;

            return this;
        }

        protected (IEnumerable<string> required, IEnumerable<string> optional) ParseArguments(IEnumerable<string> arguments)
        {
            var optionalParameters = new List<string>(); 
            var requiredParameters = new List<string>();

            for(var i = 0; i < arguments.Count(); ++i)
            {
                var currentArgument = arguments.ElementAt(i);
                if (IsRequiredParameter.Validate(currentArgument))
                {
                    requiredParameters.Add(currentArgument);
                    continue;
                }
                
                if (currentArgument.Contains("=") && currentArgument.Split('=').Length == 2)
                {
                    optionalParameters.Add(currentArgument);
                    continue;
                }

                if (currentArgument.Contains("=") == false && i + 2 < arguments.Count() && arguments.ElementAt(i + 1).Trim() == "=")
                {
                    optionalParameters.Add(currentArgument + arguments.ElementAt(i + 1) + arguments.ElementAt(i + 2));
                    i += 2;
                }
            }

            return (requiredParameters, optionalParameters);
        }
    }
}

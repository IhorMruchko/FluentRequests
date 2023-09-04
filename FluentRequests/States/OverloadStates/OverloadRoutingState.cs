using FluentRequests.Lib.Callable.CallableOverload;
using FluentRequests.Lib.States.Base;
using FluentRequests.Lib.Validation.Base;
using System.Collections.Generic;
using System.Linq;

namespace FluentRequests.Lib.States.OverloadStates
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
        public Overload OverloadSource => (Overload)Context;

        protected (IEnumerable<string> required, IEnumerable<string> optional) ParseArguments(IEnumerable<string> arguments)
        {
            var optionalParameters = new List<string>();
            var requiredParameters = new List<string>();

            for (var i = 0; i < arguments.Count(); ++i)
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
                    optionalParameters.Add(currentArgument.Trim() + arguments.ElementAt(i + 1).Trim() + arguments.ElementAt(i + 2).Trim());
                    i += 2;
                }
            }

            return (requiredParameters, optionalParameters);
        }
    }



}

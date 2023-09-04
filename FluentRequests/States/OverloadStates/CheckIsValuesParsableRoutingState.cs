using FluentRequests.Lib.Callable.Arguments;
using FluentRequests.Lib.States.Base;
using FluentRequests.Lib.States.Base.TerminationStates;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Tasks;

namespace FluentRequests.Lib.States.OverloadStates
{
    internal class CheckIsValuesParsableRoutingState : OverloadRoutingState
    {
        public IEnumerable<string> ParsedRequiredArguments { get; set; }
        
        public IEnumerable<string> ParsedOptonalArguments { get; set; }

        public override string Execute()
        {
            return string.Empty;
        }

        public override Task<string> ExecuteAsync()
        {
            return Task.FromResult(string.Empty);
        }

        public override void Route(IEnumerable<string> argumetns)
        {
            var passedRequired = 0;
            foreach(var (requiredArgument, value) in OverloadSource.RequiredArguments.Zip(ParsedRequiredArguments, (requiredArgument, value) => (requiredArgument, value)))
            {
                if (requiredArgument.TryParse(value) == false) 
                {
                    Context.ChangeState(new ArgumentIsNotConvertedTerminationRoutingState()
                    {
                        RoutingPersentage = RoutingPersentage + passedRequired,
                        Type = requiredArgument.GetType().GetGenericArguments()[0],
                        Value = value,
                    });
                    return;
                }
                ++passedRequired;
            }

            if (ParsedOptonalArguments.Any() == false)
            {
                Context.ChangeState(new CheckArgumentsValidationRoutingState()
                {
                    RoutingPersentage = RoutingPersentage + 0 + passedRequired
                });
                return;
            }

            ArgumentBase missedArgument = null;
            int parsedOptionals = 0;
            string suitableValue = string.Empty;
            foreach (var optional in OverloadSource.OptionalArguments)
            {
                suitableValue = ParsedOptonalArguments.First(arg => arg.Split('=')[0].Trim('#', '-').Equals(optional.Name, System.StringComparison.InvariantCultureIgnoreCase));
                if (optional.TryParse(suitableValue.Split('=')[1]) == false)
                {
                    missedArgument = optional;
                }
                else
                {
                    ++parsedOptionals;
                }
            }

            if (missedArgument is null == false)
            {
                Context.ChangeState(new OptionalArgumentIsNotParsedTerminationRoutingState()
                {
                    Argument = missedArgument,
                    Value = suitableValue.Split('=')[1],
                    RoutingPersentage = RoutingPersentage + parsedOptionals + passedRequired,
                });
                return;
            }

            Context.ChangeState(new CheckArgumentsValidationRoutingState()
            {
                RoutingPersentage = RoutingPersentage + parsedOptionals + passedRequired
            });
        }
    }
}
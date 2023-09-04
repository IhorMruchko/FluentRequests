using FluentRequests.Lib.States.Base;
using FluentRequests.Lib.States.Base.TerminationStates;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentRequests.Lib.States.OverloadStates
{
    internal class CheckArgumentsLenghtRoutingState : OverloadRoutingState
    {
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
            foreach(var optionalArgument in OverloadSource.OptionalArguments)
            {
                optionalArgument.Value = null;
            }

            var parameterArguments = argumetns.Skip(PassedArgumentsAmount).ToArray();
            var (requiredArguments, optionalArguments) = ParseArguments(parameterArguments);

            if (OverloadSource.RequiredArguments.Any() == false 
                && parameterArguments.Any() == false)
            {
                Context.ChangeState(new ExitRoutingState()
                {
                    Overload = OverloadSource,
                    RoutingPersentage = RoutingPersentage + 1,
                });
                return;
            }

            if (requiredArguments.Count() != OverloadSource.RequiredArguments.Count())
            {
                Context.ChangeState(new InvalidParameterAmountTerminationState()
                {
                    ArgumetnsBefore = argumetns.Take(PassedArgumentsAmount),
                    Overload = OverloadSource,
                    RoutingPersentage = RoutingPersentage
                });
                return;
            }

            var names = optionalArguments.Select(arg => arg.Split('=')[0].Trim('-', '#')).ToArray();
            var possibleNames = OverloadSource.OptionalArguments.Select(opt => opt.Name).ToArray();

            if (OverloadSource.OptionalArguments.Any() == false && optionalArguments.Any())
            {
                Context.ChangeState(new OverloadDoesNotContainOptionalsTerminationRoutingState()
                {
                    ArgumetnsBefore = argumetns.Take(PassedArgumentsAmount),
                    Overload = OverloadSource,
                    RoutingPersentage = RoutingPersentage,
                    Names = names
                });
                return;
            }
            var haveOptional = 0;
            foreach(var name in names)
            {
                if (possibleNames.Contains(name) == false)
                {
                    Context.ChangeState(new OverloadDoesNotContainOptionalTerminationRoutingState()
                    {
                        ArgumetnsBefore = argumetns.Take(PassedArgumentsAmount),
                        Overload = OverloadSource,
                        RoutingPersentage = RoutingPersentage + haveOptional,
                        Name = name
                    });
                    return;
                }
                haveOptional++;
            }

            Context.ChangeState(new CheckIsValuesParsableRoutingState()
            {
                ParsedRequiredArguments = requiredArguments,
                ParsedOptonalArguments = optionalArguments,
                RoutingPersentage = RoutingPersentage + haveOptional + OverloadSource.RequiredArguments.Count()
            });
        }
    }
}

using FluentRequests.Lib.Callable.CallableCommand;
using FluentRequests.Lib.States.Base.TerminationStates;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentRequests.Lib.States.CommandStates
{
    internal class CheckCommandNameRoutingState : CommandRoutingState
    {
        public Command CalledFrom { get; set; }

        public override string Execute() 
            => string.Empty;

        public override Task<string> ExecuteAsync() 
            => Task.FromResult(string.Empty);

        public override void Route(IEnumerable<string> argumetns)
        {
            if(PassedArgumentsAmount == 0 && argumetns.Any() == false)
            {
                Context.ChangeState(new EmptyArgumentsTerminationRoutingState() { RoutingPersentage = 0 });
                return;
            }

            if (PassedArgumentsAmount < argumetns.Count()
                && argumetns.ElementAt(PassedArgumentsAmount).Equals(CommandSource.Name, System.StringComparison.InvariantCulture))
            {
                Context.ChangeState(new CheckInnerCommandsRoutingState()
                {
                    PassedArgumentsAmount = PassedArgumentsAmount + 1,
                    RoutingPersentage = RoutingPersentage + 1
                });
                return;
            }

            if (CalledFrom is null)
            {
                Context.ChangeState(new NamingTerminationRoutingState()
                {
                    RoutingPersentage = RoutingPersentage,
                    Arguments = argumetns,
                });
                return;
            }
            Context.ChangeState(new NamingWithKnownCommandTerminationRoutingState()
            {
                RoutingPersentage = RoutingPersentage,
                Arguments = argumetns.Take(PassedArgumentsAmount + 1),
                TargetCommand = CalledFrom
            });
        }
    }
}

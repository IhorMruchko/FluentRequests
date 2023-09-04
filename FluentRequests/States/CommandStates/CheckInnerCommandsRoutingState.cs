using FluentRequests.Lib.States.Base;
using FluentRequests.Lib.States.Base.TerminationStates;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentRequests.Lib.States.CommandStates
{
    internal class CheckInnerCommandsRoutingState : CommandRoutingState
    {
        public override string Execute() 
            => string.Empty;

        public override async Task<string> ExecuteAsync() 
            => await Task.FromResult(string.Empty);

        public override void Route(IEnumerable<string> argumetns)
        {
            if (CommandSource.InnerCommands.Any() == false)
            {
                Context.ChangeState(new CheckOverloadsRoutingState()
                {
                    RoutingPersentage = RoutingPersentage,
                    PassedArgumentsAmount = PassedArgumentsAmount,
                    BestInnerCommandRouted = CommandSource
                });
                return;
            }

            foreach (var innerCommand in CommandSource.InnerCommands)
            {
                ((IRoutingContext)innerCommand).ChangeState(new CheckCommandNameRoutingState()
                {
                    CalledFrom = CommandSource,
                    PassedArgumentsAmount = PassedArgumentsAmount,
                    RoutingPersentage = RoutingPersentage
                });
                innerCommand.IsCalled(argumetns);
            }

            var orderedInnerCommands = CommandSource.InnerCommands.OrderByDescending(c => c.CurrentState.RoutingPersentage).ToArray();

            if (orderedInnerCommands.Any() == false || orderedInnerCommands[0].CurrentState is TerminationRoutingState) 
            {
                Context.ChangeState(new CheckOverloadsRoutingState()
                {
                    RoutingPersentage = RoutingPersentage,
                    PassedArgumentsAmount = PassedArgumentsAmount,
                    BestInnerCommandRouted = orderedInnerCommands.FirstOrDefault()
                });
                return;
            }

            Context.ChangeState(orderedInnerCommands[0].CurrentState);
        }
    }
}
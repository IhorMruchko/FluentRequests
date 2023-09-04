using FluentRequests.Lib.Callable.CallableCommand;
using FluentRequests.Lib.States.Base;
using FluentRequests.Lib.States.OverloadStates;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentRequests.Lib.States.CommandStates
{
    internal class CheckOverloadsRoutingState : CommandRoutingState
    {
        public Command BestInnerCommandRouted { get; set; }

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
            if (CommandSource.Overloads.Any() == false)
            {
                Context.ChangeState(BestInnerCommandRouted.CurrentState);
                return;
            }

            foreach (var overload in CommandSource.Overloads)
            {
                ((IRoutingContext)overload).ChangeState(new CheckArgumentsLenghtRoutingState()
                {
                    PassedArgumentsAmount = PassedArgumentsAmount,
                    RoutingPersentage = RoutingPersentage
                });
                overload.IsCalled(argumetns);
            }

            var topOverload = CommandSource.Overloads.OrderByDescending(o => o.CurrentState.RoutingPersentage).FirstOrDefault();
            if (topOverload is null)
            {
                Context.ChangeState(BestInnerCommandRouted.CurrentState);
                return;
            }

            Context.ChangeState(topOverload.CurrentState);

        }
    }
}
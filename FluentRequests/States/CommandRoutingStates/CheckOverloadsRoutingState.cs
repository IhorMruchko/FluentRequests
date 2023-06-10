using FluentRequests.Lib.States.Base;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace FluentRequests.Lib.States.CommandRoutingStates
{
    internal class CheckOverloadsRoutingState : CommandRoutingState
    {
        public CheckOverloadsRoutingState(IEnumerable<string> args = null) : base(args)
        {
        }

        public override void Route()
        {
            if (CommandSource.Overloads.Any() == false)
            {
                Source.ChangeState(new TerminateRoutingState());
                return;
            }

            var possibleOverloads = CommandSource.Overloads.Where(o => o.IsCalled(Arguments)).ToArray();

            if (possibleOverloads.Any() == false)
            {
                Source.ChangeState(new TerminateRoutingState());
                return;
            }

            var validOverloads = possibleOverloads.Where(o => o.RequiredArguments.All(r => r.Validate()) && o.OptionalArguments.All(r => r.Validate()));
            
            if (validOverloads.Any() == false)
            {
                Source.ChangeState(new TerminateRoutingState());
                return;
            }

            Source.ChangeState(possibleOverloads.OrderByDescending(o => o.CurrentState.RoutingCoefficient)
                                                .First().CurrentState);
        }
    }
}
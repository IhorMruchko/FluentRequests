using System.Collections.Generic;
using System.Linq;
using FluentRequests.Lib.States.Base;

namespace FluentRequests.Lib.States.CommandRoutingStates
{
    internal class CheckCommandNameRoutingState : CommandRoutingState
    {
        public CheckCommandNameRoutingState(IEnumerable<string> args) : base(args)
        {
        }


        public override void Route()
        {
            if (Arguments.Any() == false)
            {
                Source.ChangeState(new CheckOverloadsRoutingState(Arguments), ValidCommandName);
                return;
            }
            if (Arguments.ElementAt(0).Equals(CommandSource.Name, System.StringComparison.InvariantCultureIgnoreCase))
            {
                Source.ChangeState(Arguments.Count() == 1
                    ? (RoutingState)new CheckOverloadsRoutingState(Arguments.Skip(1))
                    : new CheckInnerCommandsRoutingState(Arguments.Skip(1).ToArray()), ValidCommandName);
                return;
            }
            Source.ChangeState(new TerminateRoutingState());
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using FluentRequests.Lib.States.Base;

namespace FluentRequests.Lib.States.CommandRoutingStates
{
    internal class CheckInnerCommandsRoutingState : CommandRoutingState
    {
        public CheckInnerCommandsRoutingState(IEnumerable<string> args) : base(args)
        {
        }

        public override void Route()
        {
            if (CommandSource.InnerCommands.Any() == false)
            {
                Source.ChangeState(new CheckOverloadsRoutingState(Arguments));
                return;
            }

            var calledCommands = CommandSource.InnerCommands.Where(c => c.IsCalled(Arguments));

            if (calledCommands.Any() == false)
            {
                Source.ChangeState(new CheckOverloadsRoutingState(Arguments));
                return;
            }

            Source.ChangeState(calledCommands.First().State);
        }
    }
}
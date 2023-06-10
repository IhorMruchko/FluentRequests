using System.Collections.Generic;
using System.Threading.Tasks;
using FluentRequests.Lib.Callable.CallableCommand;
using FluentRequests.Lib.States.Base;

namespace FluentRequests.Lib.States
{
    internal class TerminateRoutingState : RoutingState
    {
        public TerminateRoutingState(IEnumerable<string> args = null) : base(args)
        {
        }

        public override void Route()
        {

        }

        public override string Execute() => $"Cannot find proper routing handlers. Most suitable is {((Command)Source).Name}";

        public override async Task<string> ExecuteAsync() 
            => await Task.FromResult("Cannot find proper routing handlers");
    }
}

using FluentRequests.Lib.Callable.CallableOverload;
using FluentRequests.Lib.States.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FluentRequests.Lib.States
{
    internal class ExitRoutingState : RoutingState
    {
        public Overload Overload { get; set; }

        public ExitRoutingState(IEnumerable<string> args = null) : base(args)
        {
        }

        public override string Execute() 
            => Overload.Execute();

        public override async Task<string> ExecuteAsync() 
            => await Overload.ExecuteAsync();

        public override void Route()
        {
            
        }
    }
}

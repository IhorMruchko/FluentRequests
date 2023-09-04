using FluentRequests.Lib.Callable.CallableOverload;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FluentRequests.Lib.States.Base
{
    internal class ExitRoutingState : RoutingState
    {
        public Overload Overload { get; set; }

        public override string Execute()
        {
            return Overload.Execute();
        }

        public override async Task<string> ExecuteAsync()
        {
            return await Overload.ExecuteAsync();
        }

        public override void Route(IEnumerable<string> argumetns)
        {
            
        }
    }
}

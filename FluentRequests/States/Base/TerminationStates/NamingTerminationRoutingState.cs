using FluentRequests.Lib.Callable.CallableCommand;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentRequests.Lib.States.Base.TerminationStates
{
    internal class NamingTerminationRoutingState : TerminationRoutingState
    {
        public IEnumerable<string> Arguments { get; set; }

        public override string Execute()
        {
            return $"Cannot route `{string.Join(" ", Arguments)}` request. Use help to find out existing command";
        }

        public override async Task<string> ExecuteAsync() 
            => await Task.FromResult(Execute());

        public override void Route(IEnumerable<string> argumetns)
        {
        }
    }
}

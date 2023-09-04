using System.Collections.Generic;
using System.Threading.Tasks;

namespace FluentRequests.Lib.States.Base.TerminationStates
{
    internal class EmptyArgumentsTerminationRoutingState : TerminationRoutingState
    {
        public override string Execute() 
            => Settings.Routing.NoArgumentsProvided;

        public override async Task<string> ExecuteAsync() 
            => await Task.FromResult(Settings.Routing.NoArgumentsProvided);

        public override void Route(IEnumerable<string> argumetns)
        {
            
        }
    }
}

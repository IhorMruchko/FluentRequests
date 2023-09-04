using FluentRequests.Lib.Callable.CallableOverload;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FluentRequests.Lib.States.Base.TerminationStates
{
    internal class InvalidParameterAmountTerminationState : TerminationRoutingState
    {
        public Overload Overload { get; internal set; }

        public IEnumerable<string> ArgumetnsBefore { get; internal set; }

        public override string Execute() 
            => $"Overload does not fit arguments amount. See more about this overload of {string.Join(" ", ArgumetnsBefore)}:\n{Overload}";

        public override async Task<string> ExecuteAsync() => await Task.FromResult(Execute());

        public override void Route(IEnumerable<string> argumetns)
        {
        }
    }
}

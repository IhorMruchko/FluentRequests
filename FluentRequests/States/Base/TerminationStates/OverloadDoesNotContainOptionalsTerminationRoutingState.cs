using FluentRequests.Lib.Callable.CallableOverload;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentRequests.Lib.States.Base.TerminationStates
{
    internal class OverloadDoesNotContainOptionalsTerminationRoutingState : TerminationRoutingState
    {
        public IEnumerable<string> ArgumetnsBefore { get; set; }
        
        public Overload Overload { get; set; }
        
        public string[] Names { get; set; }

        public override string Execute()
            => $"Overload does not contains any optional arguments. But {string.Join(",", Names.Select(n => $"`{n}`"))} was provided. Find out more about the {string.Join(" ", ArgumetnsBefore)} overload:\n {Overload}";

        public override async Task<string> ExecuteAsync() 
            => await Task.FromResult(Execute());

        public override void Route(IEnumerable<string> argumetns)
        {
        }
    }
}
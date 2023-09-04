using FluentRequests.Lib.Callable.CallableOverload;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FluentRequests.Lib.States.Base.TerminationStates
{
    internal class OverloadDoesNotContainOptionalTerminationRoutingState : TerminationRoutingState
    {
        public IEnumerable<string> ArgumetnsBefore { get; set; }

        public Overload Overload { get; set; }

        public string Name { get; set; }

        public override string Execute() 
            => $"Overload does not contain {Name} optional argument. Find out more about the {string.Join(" ", ArgumetnsBefore)} overload:\n {Overload}";

        public override async Task<string> ExecuteAsync() 
            => await Task.FromResult(Execute());

        public override void Route(IEnumerable<string> argumetns)
        {

        }
    }
}
using FluentRequests.Lib.Callable.Arguments;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FluentRequests.Lib.States.Base.TerminationStates
{
    internal class OptionalArgumentIsNotParsedTerminationRoutingState : TerminationRoutingState
    {
        public ArgumentBase Argument { get; set; }
        
        public string Value { get; set; }

        public override string Execute()
        {
            return $"Can not parse optional argument {Argument.Name} from `{Value}`.";
        }

        public override async Task<string> ExecuteAsync()
        {
            return await Task.FromResult(Execute());
        }

        public override void Route(IEnumerable<string> argumetns)
        {

        }
    }
}
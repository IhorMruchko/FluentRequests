using FluentRequests.Lib.Callable.Arguments;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FluentRequests.Lib.States.Base.TerminationStates
{
    internal class ArgumentDoesNotFitValidationTerminationRoutingState : TerminationRoutingState
    {
        public ArgumentBase Argument { get; set; }

        public override string Execute()
            => $"Argument {Argument.Name} is not valid due to {Argument.Validation.GetMessage(Argument.Value)}";

        public override async Task<string> ExecuteAsync()
            => await Task.FromResult(Execute());

        public override void Route(IEnumerable<string> argumetns)
        {
        }
    }
}
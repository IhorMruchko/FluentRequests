using FluentRequests.Lib.Callable.Arguments;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FluentRequests.Lib.States.Base.TerminationStates
{
    internal class ArgumentDoesNotFitConstraintTerminationRoutingState : TerminationRoutingState
    {
        public ArgumentBase Argument { get; set; }

        public override string Execute() 
            => $"Argument {Argument.Name} does not fit constraint {Argument.Constraint.GetMessage(Argument.Value)}";

        public override async Task<string> ExecuteAsync() 
            => await Task.FromResult(Execute());

        public override void Route(IEnumerable<string> argumetns)
        {
            
        }
    }
}
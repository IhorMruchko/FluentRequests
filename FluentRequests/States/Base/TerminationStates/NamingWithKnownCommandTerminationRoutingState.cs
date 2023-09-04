using FluentRequests.Lib.Callable.CallableCommand;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FluentRequests.Lib.States.Base.TerminationStates
{
    internal class NamingWithKnownCommandTerminationRoutingState : TerminationRoutingState
    {
        public IEnumerable<string> Arguments { get; set; }
        
        public Command TargetCommand { get; set; }

        public override string Execute() 
            => $"Cannot find proper routing for `{string.Join(" ", Arguments)}`.\n" +
                $"May be you mean this command:\n{TargetCommand.ToInnerString()}";

        public override async Task<string> ExecuteAsync() 
            => await Task.FromResult(Execute());

        public override void Route(IEnumerable<string> argumetns)
        {
            throw new System.NotImplementedException();
        }
    }
}
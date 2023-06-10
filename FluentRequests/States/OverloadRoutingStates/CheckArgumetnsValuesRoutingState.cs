using FluentRequests.Lib.Callable.Arguments;
using FluentRequests.Lib.States.Base;
using System.Collections.Generic;
using System.Linq;

namespace FluentRequests.Lib.States.OverloadRoutingStates
{
    internal class CheckArgumetnsValuesRoutingState : OverloadRoutingState
    {
        public CheckArgumetnsValuesRoutingState(IEnumerable<string> args = null) : base(args)
        {
        }

        public IEnumerable<(ArgumentBase argument, string value)> RequiredArgumentValues { get; set; }
        
        public IEnumerable<(ArgumentBase argument, string value)> OptionalArgumentsValues { get; set; }

        public override void Route()
        {
            if (RequiredArgumentValues.Any() == false
                && OptionalArgumentsValues.Any() == false 
                && OverloadSource.RequiredArguments.Count == 0
                && OverloadSource.OptionalArguments.Count == 0)
            {
                Source.ChangeState(new ExitRoutingState() { Overload = OverloadSource }, ValidOverload);
                return;
            }

            if (RequiredArgumentValues.All(z => z.argument.TryParse(z.value) && z.argument.FitContraint()) &&
                OptionalArgumentsValues.All(z => z.argument.TryParse(z.value) && z.argument.FitContraint()))
            {
                Source.ChangeState(new ExitRoutingState() { Overload = OverloadSource }, ValidOverload);
                return;
            }
            
            Source.ChangeState(new TerminateRoutingState());
        }
    }
}
using FluentRequests.Lib.States.Base;
using FluentRequests.Lib.States.Base.TerminationStates;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FluentRequests.Lib.States.OverloadStates
{
    internal class CheckArgumentsValidationRoutingState : OverloadRoutingState
    {
        public override string Execute()
        {
            return string.Empty;
        }

        public override async Task<string> ExecuteAsync()
        {
            return await Task.FromResult(string.Empty);
        }

        public override void Route(IEnumerable<string> argumetns)
        {
            for(var i = 0; i < OverloadSource.RequiredArguments.Count; ++i)
            {
                var currentRequiredArgument = OverloadSource.RequiredArguments[i];
                if (currentRequiredArgument.FitContraint() == false) 
                {
                    Context.ChangeState(new ArgumentDoesNotFitConstraintTerminationRoutingState()
                    {
                        Argument = currentRequiredArgument,
                        RoutingPersentage = RoutingPersentage + i,
                    });
                    return;
                }

                if (currentRequiredArgument.Validate() == false)
                {
                    Context.ChangeState(new ArgumentDoesNotFitValidationTerminationRoutingState()
                    {
                        Argument = currentRequiredArgument,
                        RoutingPersentage = RoutingPersentage + i,
                    });
                    return;
                }
            }

            var passedOptionalArgumentsAmount = 0;
            for(var i = 0; i < OverloadSource.OptionalArguments.Count; ++i)
            {
                var currentOptionalArgument = OverloadSource.OptionalArguments[i];
                if (currentOptionalArgument.Value != null && currentOptionalArgument.FitContraint() == false)
                {
                    Context.ChangeState(new ArgumentDoesNotFitConstraintTerminationRoutingState()
                    {
                        Argument = currentOptionalArgument,
                        RoutingPersentage = OverloadSource.RequiredArguments.Count + passedOptionalArgumentsAmount
                    });
                    return;
                }

                if (currentOptionalArgument.Value != null && currentOptionalArgument.Validate() == false)
                {
                    Context.ChangeState(new ArgumentDoesNotFitValidationTerminationRoutingState()
                    {
                        Argument = currentOptionalArgument,
                        RoutingPersentage = OverloadSource.RequiredArguments.Count + passedOptionalArgumentsAmount
                    });
                    return;
                }
                passedOptionalArgumentsAmount += 1;
            }

            Context.ChangeState(new ExitRoutingState()
            {
                Overload = OverloadSource,
                RoutingPersentage = RoutingPersentage + passedOptionalArgumentsAmount + OverloadSource.RequiredArguments.Count
            }); 
        }
    }
}
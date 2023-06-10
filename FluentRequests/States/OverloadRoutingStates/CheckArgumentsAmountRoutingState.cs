using FluentRequests.Lib.Callable.Arguments;
using FluentRequests.Lib.Extensions;
using FluentRequests.Lib.States.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentRequests.Lib.States.OverloadRoutingStates
{
    internal class CheckArgumentsAmountRoutingState : OverloadRoutingState
    {
        public CheckArgumentsAmountRoutingState(IEnumerable<string> arguments) : base(arguments)
        {
        }

        public override void Route()
        {
            var (requiredArguments, optionalArguments) = ParseArguments(Arguments);

            if (requiredArguments.Count() != OverloadSource.RequiredArguments.Count)
            {
                Source.ChangeState(new TerminateRoutingState());
                return;
            }

            var zippedRequired =
            optionalArguments.Decompose()
                             .Get(args => args.Select(a => a.Split('=')), out var splittedValues)
                             .Get(_ => splittedValues.Select(a => a[0].TrimStart('-', '#')).ToArray(), out var optionalArgumentsNames)
                             .Get(_ => splittedValues.Select(a => a.Length == 2 ? a[1] : string.Empty).ToArray(), out var optionalArgumentsValues)
                             .Get(_ => OverloadSource.OptionalArguments.Select(o => o.Name), out var possibleOptionalArgumentsNames)
                             .Get(_ => optionalArgumentsNames.All(n => possibleOptionalArgumentsNames.Contains(n)), out var isValidParameters)
                             .Get(_ => optionalArgumentsNames.Zip(optionalArgumentsValues, (name, value) => (name, value)), out var zipped)
                             .Get(_ => OverloadSource.RequiredArguments.Zip(requiredArguments, (argument, value) => (argument, value)));


            if (isValidParameters == false)
            {
                Source.ChangeState(new TerminateRoutingState());
                return;
            }

            Source.ChangeState(new CheckArgumetnsValuesRoutingState(Arguments)
            {
                RequiredArgumentValues = zippedRequired,
                OptionalArgumentsValues = zipped.Any() 
                ? OverloadSource.OptionalArguments.Select(argument => (argument, zipped.First(z => z.name.Equals(argument.Name, StringComparison.InvariantCultureIgnoreCase)).value))
                : Enumerable.Empty<(ArgumentBase, string)>()
            }, (requiredArguments.Count() + zipped.Count()) * ValidParameters);
        }
    }
}

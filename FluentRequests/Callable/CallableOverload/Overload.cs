using FluentRequests.Lib.Building;
using FluentRequests.Lib.Building.OverloadBuilding;
using FluentRequests.Lib.Callable.Arguments;
using FluentRequests.Lib.States;
using FluentRequests.Lib.States.Base;
using FluentRequests.Lib.States.OverloadRoutingStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentRequests.Lib.Callable.CallableOverload
{
    public class Overload : ICallable, IExecutable, IRoutingSource
    {
        public static IHelpSetter<IParametersSetter> BeginInit()
            => new OverloadBuilder();

        internal string Help { get; set; }

        internal Func<List<ArgumentBase>, List<ArgumentBase>, string> Body { get; set; }

        internal List<ArgumentBase> RequiredArguments { get; set; } = new List<ArgumentBase>();

        internal List<ArgumentBase> OptionalArguments { get; set; } = new List<ArgumentBase>();

        internal RoutingState CurrentState { get; set; }

        RoutingState IRoutingSource.CurrentState => CurrentState;

        public bool IsCalled(IEnumerable<string> arguments)
        {
            CurrentState = new CheckArgumentsAmountRoutingState(arguments).SetSource(this);
            
            while (CurrentState.CanContinueRouting())
                CurrentState.Route();
            
            return CurrentState is ExitRoutingState;
        }
       
        public string Execute() 
            => Body(RequiredArguments, OptionalArguments);

        public async Task<string> ExecuteAsync() 
            => await Task.FromResult(Body(RequiredArguments, OptionalArguments));

        RoutingState IRoutingSource.ChangeState(RoutingState currentState, float increment)
        {
            CurrentState = currentState.SetSource(this).UpdateCoeficient(CurrentState.RoutingCoefficient + increment);
            return CurrentState;
        }

        public override string ToString() 
            => $"({string.Join(", ", RequiredArguments.Concat(OptionalArguments).Select(a => a.ToString()))}) - {Help}";
    }
}

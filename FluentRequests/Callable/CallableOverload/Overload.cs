using FluentRequests.Lib.Building;
using FluentRequests.Lib.Building.OverloadBuilding;
using FluentRequests.Lib.Callable.Arguments;
using FluentRequests.Lib.States.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentRequests.Lib.Callable.CallableOverload
{
    public class Overload : ICallable, IExecutable, IRoutingContext
    {
        public static IHelpSetter<IParametersSetter> BeginInit()
            => new OverloadBuilder();

        internal string Help { get; set; }

        internal Func<List<ArgumentBase>, List<ArgumentBase>, string> Body { get; set; }

        internal List<ArgumentBase> RequiredArguments { get; set; } = new List<ArgumentBase>();

        internal List<ArgumentBase> OptionalArguments { get; set; } = new List<ArgumentBase>();

        internal RoutingState CurrentState { get; set; }

        RoutingState IRoutingContext.State => CurrentState;

        public bool IsCalled(IEnumerable<string> arguments)
        {
            while (CurrentState.CanRoute())
                CurrentState.Route(arguments);
            return CurrentState is ExitRoutingState;
        }
       
        public string Execute() 
            => Body(RequiredArguments, OptionalArguments);

        public async Task<string> ExecuteAsync() 
            => await Task.FromResult(Body(RequiredArguments, OptionalArguments));

        public override string ToString() 
            => $"({string.Join(", ", RequiredArguments.Concat(OptionalArguments).Select(a => a.ToString()))}) - {Help}";

        void IRoutingContext.ChangeState(RoutingState newState)
        {
            CurrentState = newState;
            CurrentState.SetContext(this);
        }
    }
}

using FluentRequests.Lib.Building.CommandBuilding;
using FluentRequests.Lib.Callable.CallableOverload;
using FluentRequests.Lib.States.Base;
using FluentRequests.Lib.States.CommandStates;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentRequests.Lib.Callable.CallableCommand
{
    public class Command : ICallable, IExecutable, IRoutingContext
    {
        public string Name { get; internal set; }

        public string Help { get; internal set; }

        internal List<Command> InnerCommands { get; } = new List<Command>();
        
        internal List<Overload> Overloads { get; } = new List<Overload>();

        internal RoutingState CurrentState { get; set; }

        RoutingState IRoutingContext.State => CurrentState;

        public static ICommandNameSetter BeginInit() 
            => new CommandBuilder();

        public bool IsCalled(IEnumerable<string> arguments)
        {
            while (CurrentState.CanRoute())
                CurrentState.Route(arguments);
            return CurrentState is ExitRoutingState;
        }

        public string Execute()
            => CurrentState.Execute();

        public async Task<string> ExecuteAsync()
            => await CurrentState.ExecuteAsync();

        public override string ToString() 
            => $"Information for command {Name}:\n" +
                (InnerCommands.Any() ? $"\tInnerCommands:\n" +
                $"\t\t{string.Join("\n\t\t", InnerCommands.Select(c => c.Name))}\n\t" : string.Empty) +
                (Overloads.Any() ? "\tOverloads:\n" +
                $"\t\t{string.Join("\n\t\t", Overloads.Select(o => o.ToString()))}" : string.Empty);

        public string ToInnerString(int level = 0)
            => $"Information for command {Name}:\n" +
                (InnerCommands.Any() ? $"{new string('\t', 1 + level)}InnerCommands:\n" +
                $"{new string('\t', 2 + level)}{string.Join($"\n{new string('\t', 2 + level)}", InnerCommands.Select(c => c.ToInnerString(level + 1)))}" : string.Empty) +
                (Overloads.Any() ? $"{new string('\t', 1 + level)}Overloads:\n" +
                $"{new string('\t', 2 + level)}{string.Join($"\n{new string('\t', 2 + level)}", Overloads.Select(o => o.ToString()))}" : string.Empty);

        void IRoutingContext.ChangeState(RoutingState newState)
        {
            CurrentState = newState;
            CurrentState.SetContext(this);
        }
    }
}

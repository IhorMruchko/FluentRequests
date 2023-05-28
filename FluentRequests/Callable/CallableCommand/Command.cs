using FluentRequests.Lib.Building.CommandBuilding;
using FluentRequests.Lib.Callable.CallableOverload;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FluentRequests.Lib.Callable.CallableCommand
{
    public class Command : ICallable, IExecutable
    {
        public string Name { get; internal set; }

        public string Help { get; internal set; }

        internal List<Command> InnerCommands { get; } = new List<Command>();
        
        internal List<Overload> Overloads { get; } = new List<Overload>();

        public static ICommandNameSetter BeginInit() => new CommandBuilder();

        public bool IsCalled(IEnumerable<string> arguments)
        {
            throw new System.NotImplementedException();
        }
        
        public string Execute()
        {
            throw new System.NotImplementedException();
        }

        public Task<string> ExecuteAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}

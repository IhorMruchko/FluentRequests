using FluentRequests.Lib.Building.CommandBuilding;
using FluentRequests.Lib.Callable.CallableCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentRequests.Lib.Registering
{
    public class Register
    {
        internal List<Command> Commands { get; } = new List<Command>();
        
        internal Register() { }

        public Register Add(Command command)
        {
            if (RegistrationManager.CommandNames.Contains(command.Name))
                throw new ArgumentException($"Command with name {command.Name} is already present in the register", nameof(command));
            Commands.Add(command);
            return this;
        }

        public Register Add(Func<ICommandNameSetter, Command> commandInstructions)
            => Add(commandInstructions(new CommandBuilder()));

        public string Execute(IEnumerable<string> arguments)
        {
            if (Commands.Any() == false)
                return "There no any commands.";

            foreach (var command in Commands)
                command.IsCalled(arguments);

            return Commands.OrderByDescending(c => c.State.RoutingCoefficient).First().Execute();
        }

        public async Task<string> ExecuteAsync(IEnumerable<string> arguments)
        {
            if (Commands.Any() == false)
                return "There no any commands.";

            foreach (var command in Commands)
                command.IsCalled(arguments);

            return await Commands.OrderByDescending(c => c.State.RoutingCoefficient).First().ExecuteAsync();
        }
    }
}

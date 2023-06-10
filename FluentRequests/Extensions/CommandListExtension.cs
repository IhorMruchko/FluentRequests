using FluentRequests.Lib.Callable.CallableCommand;
using System.Collections.Generic;
using System.Linq;

namespace FluentRequests.Lib.Extensions
{
    public static class CommandListExtension
    {
        public static Command FindCommandByName(this List<Command> source, string commandName)
        {
            foreach(var command in source)
            {
                if (command.Name.Equals(commandName, System.StringComparison.InvariantCultureIgnoreCase)) 
                {
                    return command;
                }

                var innerCommand = command.InnerCommands.FindCommandByName(commandName);
                if (innerCommand != null)
                {
                    return innerCommand;
                }
            }
            return null;
        }

        public static IEnumerable<string> GetAllNames(this List<Command> source)
            => source.Select(c => c.Name).Concat(source.SelectMany(c => c.InnerCommands.GetAllNames())).ToArray();
    }
}

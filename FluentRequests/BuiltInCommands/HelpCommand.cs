using FluentRequests.Lib.Attributes.RoutingAttributes;
using FluentRequests.Lib.Extensions;
using FluentRequests.Lib.Registering;
using System.Linq;

namespace FluentRequests.Lib.BuiltInCommands
{
    [Command("help")]
    [Help("Provides information for the all used commands.")]
    public class HelpCommand
    {
        [Overload]
        [Help("Gets help for the command with selected name")]
        public static string GetCommandHelp([Help("Name of the command.")] string commandName,
                                            [Help("Defines is all command must be displayer with their inner commands and overloads.")] bool all = false)
        {
            var command = RegistrationManager.RoutingRegister.Commands.FindCommandByName(commandName);

            return (all ? command?.ToInnerString() : command?.ToString()) ?? $"Cannot find command with name {commandName}";
        }

        [Overload]
        [Help("Gets help for the all roots commands or all commands.")]
        public static string GetCommandHelp([Help("Defines is all command must be displayer with their inner commands and overloads.")] bool all = false)
            => all 
            ? $"All possible commands:\n\t{string.Join("\n\t", RegistrationManager.RoutingRegister.Commands.Select(c => c.ToInnerString()))}"
            : $"All root commands:\n\t{string.Join("\n\t", RegistrationManager.RoutingRegister.Commands.Select(c => $"{c.Name.ToUpper()} - {c.Help}"))}";
    }
}

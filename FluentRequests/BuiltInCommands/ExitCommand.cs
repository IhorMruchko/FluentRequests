using FluentRequests.Lib.Attributes.RoutingAttributes;
using System;

namespace FluentRequests.Lib.BuiltInCommands
{
    [Command("exit")]
    [Help("Exit the application")]
    public class ExitCommand
    {
        [Overload]
        [Help("Exits the application with valid exit code.")]
        public static string Exit()
        {
            Environment.Exit(0);
            return string.Empty;
        }
    }
}

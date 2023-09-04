using FluentRequests.Lib.Callable.CallableCommand;
using FluentRequests.Lib.States.Base;

namespace FluentRequests.Lib.States.CommandStates
{
    internal abstract class CommandRoutingState : RoutingState
    {
        public Command CommandSource => (Command)Context;
    }
}

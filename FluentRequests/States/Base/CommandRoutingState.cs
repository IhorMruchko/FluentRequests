using FluentRequests.Lib.Callable.CallableCommand;
using System;
using System.Collections.Generic;

namespace FluentRequests.Lib.States.Base
{
    internal abstract class CommandRoutingState : RoutingState
    {
        protected Command CommandSource { get; set; }

        public CommandRoutingState(IEnumerable<string> arguments) : base(arguments) { }

        public override RoutingState SetSource(IRoutingSource source)
        {
            base.SetSource(source);
            if (source is Command command == false)
                throw new ArgumentException($"Argument of the {nameof(SetSource)} must be of type {typeof(Command).Name}");

            CommandSource = command;

            return this;
        }
    }
}

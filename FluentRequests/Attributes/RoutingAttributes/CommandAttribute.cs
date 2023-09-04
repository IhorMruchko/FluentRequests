using System;

namespace FluentRequests.Lib.Attributes.RoutingAttributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CommandAttribute : Attribute
    {
        internal string CommandName { get; set; }

        public CommandAttribute(string commandName) 
        { 
            CommandName = commandName;
        }
    }
}

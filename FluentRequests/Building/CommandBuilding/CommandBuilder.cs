using FluentRequests.Lib.Building.OverloadBuilding;
using FluentRequests.Lib.Callable.CallableCommand;
using FluentRequests.Lib.Callable.CallableOverload;
using System;

namespace FluentRequests.Lib.Building.CommandBuilding
{
    public class CommandBuilder : ICommandNameSetter,
                                  IHelpSetter<ICallableSetter>,
                                  ICallableSetter,
                                  ICommandFinalizer,
                                  ICommandInitializer
    {
        private readonly Command _editableCommand = new Command();
        
        public IHelpSetter<ICallableSetter> WithName(string name)
        {
            _editableCommand.Name = name;
            return this;
        }

        public ICallableSetter WithHelp(string helpDescription)
        {
            _editableCommand.Help = helpDescription;
            return this;
        }

        public ICommandFinalizer AddInner(Command innerCommand)
        {
            _editableCommand.InnerCommands.Add(innerCommand);
            return this;
        }

        public ICommandFinalizer AddInner(Func<ICommandNameSetter, Command> innerCommandInstruction)
        {
            _editableCommand.InnerCommands.Add(innerCommandInstruction(new CommandBuilder()));
            return this;
        }

        public ICommandFinalizer AddOverload(Overload overload)
        {
            _editableCommand.Overloads.Add(overload);
            return this;
        }

        public ICommandFinalizer AddOverload(Func<IHelpSetter<IParametersSetter>, Overload> overloadInstruction)
        {
            _editableCommand.Overloads.Add(overloadInstruction(new OverloadBuilder()));
            return this;
        }

        public Command EndInit()
        {
            return _editableCommand;
        }
    }
}

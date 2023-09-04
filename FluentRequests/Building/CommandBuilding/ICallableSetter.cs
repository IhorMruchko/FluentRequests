using FluentRequests.Lib.Building.OverloadBuilding;
using FluentRequests.Lib.Callable.CallableCommand;
using FluentRequests.Lib.Callable.CallableOverload;
using System;

namespace FluentRequests.Lib.Building.CommandBuilding
{
    public interface ICallableSetter : IAfterHelpSetter
    {
        ICommandFinalizer AddInner(Command innerCommand);

        ICommandFinalizer AddInner(Func<ICommandNameSetter, Command> innerCommandInstruction);

        ICommandFinalizer AddOverload(Overload overload);

        ICommandFinalizer AddOverload(Func<IHelpSetter<IParametersSetter>, Overload> overloadInstruction);
    }
}

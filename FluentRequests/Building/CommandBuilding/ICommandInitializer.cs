using FluentRequests.Lib.Callable.CallableCommand;

namespace FluentRequests.Lib.Building.CommandBuilding
{
    public interface ICommandInitializer
    {
        Command EndInit();
    }
}

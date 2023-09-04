namespace FluentRequests.Lib.Building.CommandBuilding
{
    public interface ICommandNameSetter
    {
        IHelpSetter<ICallableSetter> WithName(string name);
    }
}

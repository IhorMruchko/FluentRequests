namespace FluentRequests.Lib.Building
{
    public interface IHelpSetter<TAfterHelpSetter>
        where TAfterHelpSetter : IAfterHelpSetter
    {
        TAfterHelpSetter WithHelp(string helpDescription);
    }
}

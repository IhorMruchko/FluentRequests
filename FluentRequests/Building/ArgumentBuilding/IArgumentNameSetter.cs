namespace FluentRequests.Lib.Building.ArgumentBuilding
{
    public interface IArgumentNameSetter<TArgumentBeforeEnd, TArgument>
    {
        IHelpSetter<IConverterSetter<TArgumentBeforeEnd, TArgument>> WithName(string name);
    }
}

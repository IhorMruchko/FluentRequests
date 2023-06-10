namespace FluentRequests.Lib.Callable.Arguments
{
    public interface IArgumentCreator<TArgumentObject, TArgument>
        where TArgumentObject : Argument<TArgument>
    {
        TArgumentObject EndInit();
    }
}
namespace FluentRequests.Lib.Converters
{
    public interface IArgumentConverter
    {
        object Converter { get; }
        
        bool IsCalled<TResult>();
    }
}

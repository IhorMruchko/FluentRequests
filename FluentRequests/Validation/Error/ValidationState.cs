namespace FluentRequests.Lib.Validation.Error
{
    public abstract class ValidationState
    {
        public abstract void OnError(string errorMessage);
    }
}

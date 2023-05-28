namespace FluentRequests.Lib.Validation.Error
{
    public class Critical : ValidationState
    {
        public override void OnError(string errorMessage)
        {
            throw new System.Exception(errorMessage);
        }
    }
}

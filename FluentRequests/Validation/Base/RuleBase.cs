namespace FluentRequests.Lib.Validation.Base
{
    public abstract class RuleBase
    {
        internal bool PreviousResult { get; set; }

        public abstract bool Validate(object value);

        public abstract bool ValidateWithError(object value);

        public abstract string GetMessage(object value);

        public abstract void DisplayMessage(object value);
    }
}

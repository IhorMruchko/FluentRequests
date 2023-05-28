namespace FluentRequests.Lib.Validation.Error
{
    public static class RulesStates
    {
        public static ValidationState Ignore => new Ignore();

        public static ValidationState Info => new Information();

        public static ValidationState Warn => new Warning();

        public static ValidationState Error => new Error();

        public static ValidationState Critical => new Critical();
    }
}

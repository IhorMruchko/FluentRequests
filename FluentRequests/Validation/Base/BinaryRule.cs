namespace FluentRequests.Lib.Validation.Base
{
    public abstract class BinaryRule<TValue> : Rule<TValue>
    {
        protected Rule<TValue> First { get; set; }

        protected Rule<TValue> Second { get; set; }

        public BinaryRule(Rule<TValue> first, Rule<TValue> second)
        {
            First = first;
            Second = second;
        }
    }
}

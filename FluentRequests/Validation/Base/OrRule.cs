using System.Linq;

namespace FluentRequests.Lib.Validation.Base
{
    internal class OrRule<TValue> : BinaryRule<TValue>
    {
        public OrRule(Rule<TValue> first, Rule<TValue> second) : base(first, second)
        {
        }

        public override bool Validate(object value)
        {
            PreviousResult = First.Validate(value) || Second.Validate(value);
            return PreviousResult;
        }

        public override string GetMessage(object value)
        {
            if (new bool[] { First.PreviousResult, Second.PreviousResult }.Any(t => t))
                return string.Empty;
            if (First.PreviousResult == false)
                return First.GetMessage(value);
            return Second.GetMessage(value);
        }

        public override void DisplayMessage(object value)
        {
            if (new bool[] { First.PreviousResult, Second.PreviousResult }.Any(t => t))
                return;
            if (First.PreviousResult == false)
            {
                First.DisplayMessage(value);
                return;
            }

            Second.DisplayMessage(value);
        }

        internal override Rule<TValue> Not() 
            => new AndRule<TValue>(First.Not(), Second.Not());
    }
}
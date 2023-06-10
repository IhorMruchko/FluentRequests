using System.Linq;

namespace FluentRequests.Lib.Validation.Base
{
    internal class AllRule : RuleBase
    {
        private readonly RuleBase[] _rules;

        public AllRule(params RuleBase[] rules) 
        { 
            _rules = rules;
        }

        public override bool Validate(object value) 
            => _rules.Any() == false || _rules.All(r => r.Validate(value));

        public override void DisplayMessage(object value) 
            => _rules.FirstOrDefault(r => r.PreviousResult == false)?.DisplayMessage(value);

        public override string GetMessage(object value) 
            => _rules.FirstOrDefault(r => r.PreviousResult == false)?.GetMessage(value)
                ?? "All rules are passed.";

        public override bool ValidateWithError(object value)
            => _rules.Any() == false || _rules.All(r => r.ValidateWithError(value));
    }
}

using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.CharRulesAttributes
{
	public class IsDigitConstraintAttribute: ConstraintAttribute
	{
		public IsDigitConstraintAttribute()
			 => Rule = CharRules.IsDigit();
	}
}
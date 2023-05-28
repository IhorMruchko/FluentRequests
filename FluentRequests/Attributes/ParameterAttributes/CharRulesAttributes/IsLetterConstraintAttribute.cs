using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.CharRulesAttributes
{
	public class IsLetterConstraintAttribute: ConstraintAttribute
	{
		public IsLetterConstraintAttribute()
			 => Rule = CharRules.IsLetter();
	}
}
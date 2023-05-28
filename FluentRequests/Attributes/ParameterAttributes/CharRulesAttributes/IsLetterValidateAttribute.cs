using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.CharRulesAttributes
{
	public class IsLetterValidateAttribute: ValidateAttribute
	{
		public IsLetterValidateAttribute()
			 => Rule = CharRules.IsLetter();
	}
}
using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.CharRulesAttributes
{
	public class IsDigitValidateAttribute: ValidateAttribute
	{
		public IsDigitValidateAttribute()
			 => Rule = CharRules.IsDigit();
	}
}
using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.CharRulesAttributes
{
	public class IsSymbolValidateAttribute: ValidateAttribute
	{
		public IsSymbolValidateAttribute()
			 => Rule = CharRules.IsSymbol();
	}
}
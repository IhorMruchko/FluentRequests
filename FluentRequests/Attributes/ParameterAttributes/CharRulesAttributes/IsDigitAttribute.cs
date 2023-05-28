using FluentRequests.Lib.Validation.Rules;
using FluentRequests.Lib.Attributes.ParameterAttributes;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.CharRulesAttributes
{
	public class IsDigitAttribute: ParameterAttribute
	{
		public IsDigitAttribute()
			 => Constraint = CharRules.IsDigit();
	}
}
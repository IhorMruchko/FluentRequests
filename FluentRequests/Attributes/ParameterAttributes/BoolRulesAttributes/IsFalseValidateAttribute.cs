using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.BoolRulesAttributes
{
	public class IsFalseValidateAttribute: ValidateAttribute
	{
		public IsFalseValidateAttribute()
			 => Rule = BoolRules.IsFalse();
	}
}
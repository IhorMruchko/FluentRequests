using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.BoolRulesAttributes
{
	public class IsTrueValidateAttribute: ValidateAttribute
	{
		public IsTrueValidateAttribute()
			 => Rule = BoolRules.IsTrue();
	}
}
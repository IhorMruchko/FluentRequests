using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.BoolRulesAttributes
{
	public class IsFalseConstraintAttribute: ConstraintAttribute
	{
		public IsFalseConstraintAttribute()
			 => Rule = BoolRules.IsFalse();
	}
}
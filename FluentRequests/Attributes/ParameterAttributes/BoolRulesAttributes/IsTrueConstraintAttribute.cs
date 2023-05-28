using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.BoolRulesAttributes
{
	public class IsTrueConstraintAttribute: ConstraintAttribute
	{
		public IsTrueConstraintAttribute()
			 => Rule = BoolRules.IsTrue();
	}
}
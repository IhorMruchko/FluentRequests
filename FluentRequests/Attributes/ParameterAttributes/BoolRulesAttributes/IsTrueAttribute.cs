using FluentRequests.Lib.Validation.Rules;
using FluentRequests.Lib.Attributes.ParameterAttributes;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.BoolRulesAttributes
{
	public class IsTrueAttribute: ParameterAttribute
	{
		public IsTrueAttribute()
			 => Constraint = BoolRules.IsTrue();
	}
}
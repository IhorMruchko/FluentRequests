using FluentRequests.Lib.Validation.Rules;
using FluentRequests.Lib.Attributes.ParameterAttributes;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.CharRulesAttributes
{
	public class IsSymbolAttribute: ParameterAttribute
	{
		public IsSymbolAttribute()
			 => Constraint = CharRules.IsSymbol();
	}
}
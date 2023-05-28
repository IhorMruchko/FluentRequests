using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.CharRulesAttributes
{
	public class IsSymbolConstraintAttribute: ConstraintAttribute
	{
		public IsSymbolConstraintAttribute()
			 => Rule = CharRules.IsSymbol();
	}
}
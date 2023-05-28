using FluentRequests.Lib.Validation.Rules;
using FluentRequests.Lib.Attributes.ParameterAttributes;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.CharRulesAttributes
{
	public class IsLetterAttribute: ParameterAttribute
	{
		public IsLetterAttribute()
			 => Constraint = CharRules.IsLetter();
	}
}
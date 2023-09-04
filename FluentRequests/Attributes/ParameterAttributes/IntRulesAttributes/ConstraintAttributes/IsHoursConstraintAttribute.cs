using FluentRequests.Lib.Validation.Error;
using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.IntRulesAttributes.ConstraintAttributes
{
	public class IsHoursConstraintAttribute: ConstraintAttribute
	{
		public IsHoursConstraintAttribute(InformingLevel level = InformingLevel.Ignore)
			 => Rule = IntRules.IsHours(level);
	}
}


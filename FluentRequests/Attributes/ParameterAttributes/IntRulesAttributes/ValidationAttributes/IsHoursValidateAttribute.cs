using FluentRequests.Lib.Validation.Error;
using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.IntRulesAttributes.ValidationAttributes
{
	public class IsHoursValidateAttribute: ValidateAttribute
	{
		public IsHoursValidateAttribute(InformingLevel level = InformingLevel.Ignore)
			 => Rule = IntRules.IsHours(level);
	}
}


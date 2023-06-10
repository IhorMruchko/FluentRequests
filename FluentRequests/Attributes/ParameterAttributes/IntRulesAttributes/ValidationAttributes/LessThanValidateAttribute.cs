using System;
using FluentRequests.Lib.Validation.Error;
using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.IntRulesAttributes.ValidationAttributes
{
	public class LessThanValidateAttribute: ValidateAttribute
	{
		public LessThanValidateAttribute(int value, InformingLevel level = InformingLevel.Ignore)
			 => Rule = IntRules.LessThan(value, level);
	}
}
using System;
using FluentRequests.Lib.Validation.Error;
using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.IntRulesAttributes.ValidationAttributes
{
	public class BetweenValidateAttribute: ValidateAttribute
	{
		public BetweenValidateAttribute(int lower, int grater, InformingLevel level = InformingLevel.Ignore)
			 => Rule = IntRules.Between(lower, grater, level);
	}
}
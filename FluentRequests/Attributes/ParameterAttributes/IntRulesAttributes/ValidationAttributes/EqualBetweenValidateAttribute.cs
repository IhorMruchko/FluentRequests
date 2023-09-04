using System;
using FluentRequests.Lib.Validation.Error;
using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.IntRulesAttributes.ValidationAttributes
{
	public class EqualBetweenValidateAttribute: ValidateAttribute
	{
		public EqualBetweenValidateAttribute(int lower, int grater, InformingLevel level = InformingLevel.Ignore)
			 => Rule = IntRules.EqualBetween(lower, grater, level);
	}
}
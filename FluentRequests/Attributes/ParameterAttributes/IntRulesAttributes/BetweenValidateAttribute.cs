using System;
using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.IntRulesAttributes
{
	public class BetweenValidateAttribute: ValidateAttribute
	{
		public BetweenValidateAttribute(int lower, int grater)
			 => Rule = IntRules.Between(lower, grater);
	}
}
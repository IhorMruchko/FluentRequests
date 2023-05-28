using System;
using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.IntRulesAttributes
{
	public class EqualBetweenValidateAttribute: ValidateAttribute
	{
		public EqualBetweenValidateAttribute(int lower, int grater)
			 => Rule = IntRules.EqualBetween(lower, grater);
	}
}
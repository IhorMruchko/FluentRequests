using System;
using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.IntRulesAttributes
{
	public class LessThanValidateAttribute: ValidateAttribute
	{
		public LessThanValidateAttribute(int value)
			 => Rule = IntRules.LessThan(value);
	}
}
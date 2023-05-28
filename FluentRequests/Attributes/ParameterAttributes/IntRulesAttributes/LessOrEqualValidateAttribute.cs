using System;
using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.IntRulesAttributes
{
	public class LessOrEqualValidateAttribute: ValidateAttribute
	{
		public LessOrEqualValidateAttribute(int value)
			 => Rule = IntRules.LessOrEqual(value);
	}
}
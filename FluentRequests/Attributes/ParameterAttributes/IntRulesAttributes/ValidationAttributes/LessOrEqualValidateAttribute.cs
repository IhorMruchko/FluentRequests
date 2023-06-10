using System;
using FluentRequests.Lib.Validation.Error;
using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.IntRulesAttributes.ValidationAttributes
{
	public class LessOrEqualValidateAttribute: ValidateAttribute
	{
		public LessOrEqualValidateAttribute(int value, InformingLevel level = InformingLevel.Ignore)
			 => Rule = IntRules.LessOrEqual(value, level);
	}
}
using System;
using FluentRequests.Lib.Validation.Error;
using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.IntRulesAttributes.ValidationAttributes
{
	public class EqualToValidateAttribute: ValidateAttribute
	{
		public EqualToValidateAttribute(int value, InformingLevel level = InformingLevel.Ignore)
			 => Rule = IntRules.EqualTo(value, level);
	}
}
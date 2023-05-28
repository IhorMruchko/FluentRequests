using System;
using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.IntRulesAttributes
{
	public class EqualToValidateAttribute: ValidateAttribute
	{
		public EqualToValidateAttribute(int value)
			 => Rule = IntRules.EqualTo(value);
	}
}
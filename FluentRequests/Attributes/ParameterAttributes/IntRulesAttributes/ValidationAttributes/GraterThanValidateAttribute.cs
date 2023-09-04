using System;
using FluentRequests.Lib.Validation.Error;
using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.IntRulesAttributes.ValidationAttributes
{
	public class GraterThanValidateAttribute: ValidateAttribute
	{
		public GraterThanValidateAttribute(int value, InformingLevel level = InformingLevel.Ignore)
			 => Rule = IntRules.GraterThan(value, level);
	}
}
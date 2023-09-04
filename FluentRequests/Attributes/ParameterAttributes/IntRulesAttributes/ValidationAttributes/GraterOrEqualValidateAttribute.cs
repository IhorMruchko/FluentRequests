using System;
using FluentRequests.Lib.Validation.Error;
using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.IntRulesAttributes.ValidationAttributes
{
	public class GraterOrEqualValidateAttribute: ValidateAttribute
	{
		public GraterOrEqualValidateAttribute(int value, InformingLevel level = InformingLevel.Ignore)
			 => Rule = IntRules.GraterOrEqual(value, level);
	}
}
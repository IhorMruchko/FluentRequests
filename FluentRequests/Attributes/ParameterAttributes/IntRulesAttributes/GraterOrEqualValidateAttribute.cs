using System;
using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.IntRulesAttributes
{
	public class GraterOrEqualValidateAttribute: ValidateAttribute
	{
		public GraterOrEqualValidateAttribute(int value)
			 => Rule = IntRules.GraterOrEqual(value);
	}
}
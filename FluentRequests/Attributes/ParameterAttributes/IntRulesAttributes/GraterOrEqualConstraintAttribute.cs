using System;
using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.IntRulesAttributes
{
	public class GraterOrEqualConstraintAttribute: ConstraintAttribute
	{
		public GraterOrEqualConstraintAttribute(int value)
			 => Rule = IntRules.GraterOrEqual(value);
	}
}
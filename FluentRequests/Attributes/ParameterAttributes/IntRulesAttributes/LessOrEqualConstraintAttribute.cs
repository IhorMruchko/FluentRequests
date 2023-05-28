using System;
using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.IntRulesAttributes
{
	public class LessOrEqualConstraintAttribute: ConstraintAttribute
	{
		public LessOrEqualConstraintAttribute(int value)
			 => Rule = IntRules.LessOrEqual(value);
	}
}
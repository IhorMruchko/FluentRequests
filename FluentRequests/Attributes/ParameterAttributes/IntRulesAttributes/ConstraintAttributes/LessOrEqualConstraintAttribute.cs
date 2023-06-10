using System;
using FluentRequests.Lib.Validation.Error;
using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.IntRulesAttributes.ConstraintAttributes
{
	public class LessOrEqualConstraintAttribute: ConstraintAttribute
	{
		public LessOrEqualConstraintAttribute(int value, InformingLevel level = InformingLevel.Ignore)
			 => Rule = IntRules.LessOrEqual(value, level);
	}
}
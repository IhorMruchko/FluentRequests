using System;
using FluentRequests.Lib.Validation.Error;
using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.IntRulesAttributes.ConstraintAttributes
{
	public class LessThanConstraintAttribute: ConstraintAttribute
	{
		public LessThanConstraintAttribute(int value, InformingLevel level = InformingLevel.Ignore)
			 => Rule = IntRules.LessThan(value, level);
	}
}
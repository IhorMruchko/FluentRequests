using System;
using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.IntRulesAttributes
{
	public class LessThanConstraintAttribute: ConstraintAttribute
	{
		public LessThanConstraintAttribute(int value)
			 => Rule = IntRules.LessThan(value);
	}
}
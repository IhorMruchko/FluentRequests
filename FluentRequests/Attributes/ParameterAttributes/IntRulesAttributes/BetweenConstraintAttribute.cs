using System;
using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.IntRulesAttributes
{
	public class BetweenConstraintAttribute: ConstraintAttribute
	{
		public BetweenConstraintAttribute(int lower, int grater)
			 => Rule = IntRules.Between(lower, grater);
	}
}
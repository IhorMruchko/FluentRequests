using System;
using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.IntRulesAttributes
{
	public class EqualBetweenConstraintAttribute: ConstraintAttribute
	{
		public EqualBetweenConstraintAttribute(int lower, int grater)
			 => Rule = IntRules.EqualBetween(lower, grater);
	}
}
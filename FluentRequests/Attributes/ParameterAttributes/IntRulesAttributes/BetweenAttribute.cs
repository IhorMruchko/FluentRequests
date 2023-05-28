using System;
using FluentRequests.Lib.Validation.Rules;
using FluentRequests.Lib.Attributes.ParameterAttributes;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.IntRulesAttributes
{
	public class BetweenAttribute: ParameterAttribute
	{
		public BetweenAttribute(int lower, int grater)
			 => Constraint = IntRules.Between(lower, grater);
	}
}
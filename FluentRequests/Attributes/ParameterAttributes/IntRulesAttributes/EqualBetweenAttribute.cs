using System;
using FluentRequests.Lib.Validation.Rules;
using FluentRequests.Lib.Attributes.ParameterAttributes;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.IntRulesAttributes
{
	public class EqualBetweenAttribute: ParameterAttribute
	{
		public EqualBetweenAttribute(int lower, int grater)
			 => Constraint = IntRules.EqualBetween(lower, grater);
	}
}
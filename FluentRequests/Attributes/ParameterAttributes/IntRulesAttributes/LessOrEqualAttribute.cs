using System;
using FluentRequests.Lib.Validation.Rules;
using FluentRequests.Lib.Attributes.ParameterAttributes;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.IntRulesAttributes
{
	public class LessOrEqualAttribute: ParameterAttribute
	{
		public LessOrEqualAttribute(int value)
			 => Constraint = IntRules.LessOrEqual(value);
	}
}
using System;
using FluentRequests.Lib.Validation.Rules;
using FluentRequests.Lib.Attributes.ParameterAttributes;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.IntRulesAttributes
{
	public class LessThanAttribute: ParameterAttribute
	{
		public LessThanAttribute(int value)
			 => Constraint = IntRules.LessThan(value);
	}
}
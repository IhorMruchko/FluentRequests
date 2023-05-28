using System;
using FluentRequests.Lib.Validation.Rules;
using FluentRequests.Lib.Attributes.ParameterAttributes;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.IntRulesAttributes
{
	public class GraterOrEqualAttribute: ParameterAttribute
	{
		public GraterOrEqualAttribute(int value)
			 => Constraint = IntRules.GraterOrEqual(value);
	}
}
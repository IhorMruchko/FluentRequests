using System;
using FluentRequests.Lib.Validation.Rules;
using FluentRequests.Lib.Attributes.ParameterAttributes;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.IntRulesAttributes
{
	public class GraterThanAttribute: ParameterAttribute
	{
		public GraterThanAttribute(int value)
			 => Constraint = IntRules.GraterThan(value);
	}
}
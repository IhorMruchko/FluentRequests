using System;
using FluentRequests.Lib.Validation.Error;
using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.IntRulesAttributes.ConstraintAttributes
{
	public class GraterThanConstraintAttribute: ConstraintAttribute
	{
		public GraterThanConstraintAttribute(int value, InformingLevel level = InformingLevel.Ignore)
			 => Rule = IntRules.GraterThan(value, level);
	}
}
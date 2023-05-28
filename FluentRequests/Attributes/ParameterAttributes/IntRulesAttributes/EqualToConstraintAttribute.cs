using System;
using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.IntRulesAttributes
{
	public class EqualToConstraintAttribute: ConstraintAttribute
	{
		public EqualToConstraintAttribute(int value)
			 => Rule = IntRules.EqualTo(value);
	}
}
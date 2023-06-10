using System;
using FluentRequests.Lib.Validation.Error;
using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.IntRulesAttributes.ConstraintAttributes
{
	public class EqualToConstraintAttribute: ConstraintAttribute
	{
		public EqualToConstraintAttribute(int value, InformingLevel level = InformingLevel.Ignore)
			 => Rule = IntRules.EqualTo(value, level);
	}
}
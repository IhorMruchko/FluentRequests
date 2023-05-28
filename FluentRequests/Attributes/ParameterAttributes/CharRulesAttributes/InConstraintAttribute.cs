using System;
using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.CharRulesAttributes
{
	public class InConstraintAttribute: ConstraintAttribute
	{
		public InConstraintAttribute(params char[] acceptableLetters)
			 => Rule = CharRules.In(acceptableLetters);
	}
}
using System;
using FluentRequests.Lib.Validation.Rules;
using FluentRequests.Lib.Attributes.ParameterAttributes;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.CharRulesAttributes
{
	public class InAttribute: ParameterAttribute
	{
		public InAttribute(params char[] acceptableLetters)
			 => Constraint = CharRules.In(acceptableLetters);
	}
}
using System;
using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.CharRulesAttributes
{
	public class InValidateAttribute: ValidateAttribute
	{
		public InValidateAttribute(params char[] acceptableLetters)
			 => Rule = CharRules.In(acceptableLetters);
	}
}
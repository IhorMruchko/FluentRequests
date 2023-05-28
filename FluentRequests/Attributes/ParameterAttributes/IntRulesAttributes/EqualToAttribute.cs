using System;
using FluentRequests.Lib.Validation.Rules;
using FluentRequests.Lib.Attributes.ParameterAttributes;

namespace FluentRequests.Lib.Attributes.ParameterAttributes.IntRulesAttributes
{
	public class EqualToAttribute: ParameterAttribute
	{
		public EqualToAttribute(int value)
			 => Constraint = IntRules.EqualTo(value);
	}
}
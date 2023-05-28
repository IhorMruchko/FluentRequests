using System;
using FluentRequests.Lib.Validation.Error;
using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Tests.RuleTests;

public partial class IntRulesTest
{
	[Test]
	[TestCase(2)]
	public void IntRules_EqualTo_ValidValue(object value)
		=> Assert.That(IntRules.EqualTo(2).Validate(value), Is.True);
	
	[Test]
	[TestCase(-1)]
	[TestCase(-2)]
	[TestCase(-3)]
	[TestCase(-4)]
	[TestCase(-5)]
	[TestCase(1)]
	[TestCase(3)]
	[TestCase(4)]
	[TestCase(5)]
	public void IntRules_EqualTo_InvalidValue(object value)
		=> Assert.That(IntRules.EqualTo(2).Validate(value), Is.False);
}
using System;
using FluentRequests.Lib.Validation.Error;
using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Tests.RuleTests;

public partial class IntRulesTest
{
	[Test]
	[TestCase(3)]
	[TestCase(4)]
	[TestCase(5)]
	public void IntRules_Between_ValidValue(object value)
		=> Assert.That(IntRules.Between(2, 10).Validate(value), Is.True);
	
	[Test]
	[TestCase(-1)]
	[TestCase(-2)]
	[TestCase(-3)]
	[TestCase(-4)]
	[TestCase(-5)]
	[TestCase(1)]
	[TestCase(11)]
	public void IntRules_Between_InvalidValue(object value)
		=> Assert.That(IntRules.Between(2, 10).Validate(value), Is.False);
}
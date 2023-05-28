using System;
using FluentRequests.Lib.Validation.Error;
using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Tests.RuleTests;

public partial class IntRulesTest
{
	[Test]
	[TestCase(2)]
	[TestCase(3)]
	[TestCase(4)]
	[TestCase(5)]
	[TestCase(10)]
	public void IntRules_EqualBetween_ValidValue(object value)
		=> Assert.That(IntRules.EqualBetween(2, 10).Validate(value), Is.True);
	
	[Test]
	[TestCase(-1)]
	[TestCase(-4)]
	[TestCase(-5)]
	[TestCase(1)]
	[TestCase(11)]
	public void IntRules_EqualBetween_InvalidValue(object value)
		=> Assert.That(IntRules.EqualBetween(2, 10).Validate(value), Is.False);
}
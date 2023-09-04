using System;
using FluentRequests.Lib.Validation.Error;
using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Tests.RuleTests;

public partial class IntRulesTest
{
	[Test]
	[TestCase(-1)]
	[TestCase(-2)]
	[TestCase(-3)]
	[TestCase(-4)]
	[TestCase(-5)]
	public void IntRules_LessThan_ValidValue(object value)
		=> Assert.That(IntRules.LessThan(0).Validate(value), Is.True);
	
	[Test]
	[TestCase(1)]
	[TestCase(2)]
	[TestCase(3)]
	[TestCase(4)]
	[TestCase(5)]
	public void IntRules_LessThan_InvalidValue(object value)
		=> Assert.That(IntRules.LessThan(0).Validate(value), Is.False);
}
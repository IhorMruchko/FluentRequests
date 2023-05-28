using System;
using FluentRequests.Lib.Validation.Error;
using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Tests.RuleTests;

public partial class IntRulesTest
{
	[Test]
	[TestCase(0)]
	[TestCase(-1)]
	[TestCase(-2)]
	[TestCase(-3)]
	[TestCase(-4)]
	public void IntRules_LessOrEqual_ValidValue(object value)
		=> Assert.That(IntRules.LessOrEqual(0).Validate(value), Is.True);
	
	[Test]
	[TestCase(1)]
	[TestCase(2)]
	[TestCase(3)]
	[TestCase(4)]
	[TestCase(5)]
	public void IntRules_LessOrEqual_InvalidValue(object value)
		=> Assert.That(IntRules.LessOrEqual(0).Validate(value), Is.False);
}
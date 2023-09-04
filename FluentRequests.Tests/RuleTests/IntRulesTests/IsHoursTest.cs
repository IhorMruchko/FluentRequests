using FluentRequests.Lib.Validation.Error;
using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Tests.RuleTests;

public partial class IntRulesTest
{
	[Test]
	[TestCase(0)]
	[TestCase(2)]
	[TestCase(7)]
	[TestCase(13)]
	[TestCase(24)]
	public void IntRules_IsHours_ValidValue(object value)
		=> Assert.That(IntRules.IsHours().Validate(value), Is.True);
	
	[Test]
	[TestCase(-1)]
	[TestCase(25)]
	[TestCase(104)]
	[TestCase(-404)]
	[TestCase(505)]
	public void IntRules_IsHours_InvalidValue(object value)
		=> Assert.That(IntRules.IsHours().Validate(value), Is.False);
}
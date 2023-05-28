using FluentRequests.Lib.Validation.Error;
using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Tests.RuleTests;

public partial class BoolRulesTest
{
	[Test]
	[TestCase(false)]
	public void BoolRules_IsFalse_ValidValue(object value)
		=> Assert.That(BoolRules.IsFalse().Validate(value), Is.True);
	
	[Test]
	[TestCase(true)]
	[TestCase(1L)]
	[TestCase(1)]
	[TestCase(1f)]
	[TestCase(1d)]
	public void BoolRules_IsFalse_InvalidValue(object value)
		=> Assert.That(BoolRules.IsFalse().Validate(value), Is.False);
}
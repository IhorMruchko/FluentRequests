using FluentRequests.Lib.Validation.Error;
using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Tests.RuleTests;

public partial class BoolRulesTest
{
	[Test]
	[TestCase(true)]
	public void BoolRules_IsTrue_ValidValue(object value)
		=> Assert.That(BoolRules.IsTrue().Validate(value), Is.True);
	
	[Test]
	[TestCase(false)]
	[TestCase(1L)]
	[TestCase(1)]
	[TestCase(1f)]
	[TestCase(1d)]
	public void BoolRules_IsTrue_InvalidValue(object value)
		=> Assert.That(BoolRules.IsTrue().Validate(value), Is.False);
}
using FluentRequests.Lib.Validation.Error;
using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Tests.RuleTests;

public partial class CharRulesTest
{
	[Test]
	[TestCase('^')]
	[TestCase('|')]
	[TestCase('=')]
	[TestCase('<')]
	[TestCase('>')]
	public void CharRules_IsSymbol_ValidValue(object value)
		=> Assert.That(CharRules.IsSymbol().Validate(value), Is.True);
	
	[Test]
	[TestCase('1')]
	[TestCase('2')]
	[TestCase(true)]
	[TestCase(1)]
	[TestCase(1L)]
	public void CharRules_IsSymbol_InvalidValue(object value)
		=> Assert.That(CharRules.IsSymbol().Validate(value), Is.False);
}
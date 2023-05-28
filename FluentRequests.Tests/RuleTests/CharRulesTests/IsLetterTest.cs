using FluentRequests.Lib.Validation.Error;
using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Tests.RuleTests;

public partial class CharRulesTest
{
	[Test]
	[TestCase('A')]
	[TestCase('b')]
	public void CharRules_IsLetter_ValidValue(object value)
		=> Assert.That(CharRules.IsLetter().Validate(value), Is.True);
	
	[Test]
	[TestCase('^')]
	[TestCase('|')]
	[TestCase('1')]
	[TestCase('2')]
	[TestCase(false)]
	[TestCase(true)]
	public void CharRules_IsLetter_InvalidValue(object value)
		=> Assert.That(CharRules.IsLetter().Validate(value), Is.False);
}
using FluentRequests.Lib.Validation.Error;
using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Tests.RuleTests;

public partial class CharRulesTest
{
	[Test]
	[TestCase('0')]
	[TestCase('1')]
	[TestCase('2')]
	[TestCase('3')]
	[TestCase('4')]
	[TestCase('5')]
	[TestCase('6')]
	[TestCase('7')]
	[TestCase('8')]
	[TestCase('9')]
	public void CharRules_IsDigit_ValidValue(object value)
		=> Assert.That(CharRules.IsDigit().Validate(value), Is.True);
	
	[Test]
	[TestCase('A')]
	[TestCase('b')]
	[TestCase("S")]
	[TestCase("i")]
	[TestCase(true)]
	[TestCase(false)]
	[TestCase(1)]
	[TestCase(1d)]
	[TestCase(1L)]
	[TestCase(1f)]
	public void CharRules_IsDigit_InvalidValue(object value)
		=> Assert.That(CharRules.IsDigit().Validate(value), Is.False);
}
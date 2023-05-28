using System;
using FluentRequests.Lib.Validation.Rules;

namespace FluentRequests.Tests.RuleTests;

public partial class CharRulesTest
{
	[Test]
	[TestCase('A')]
	[TestCase('b')]
	[TestCase('+')]
	[TestCase('3')]
	public void CharRules_In_ValidValue(object value)
		=> Assert.That(CharRules.In('A', 'b', '+', '3').Validate(value), Is.True);
	
	[Test]
	[TestCase('^')]
	[TestCase('|')]
	[TestCase('1')]
	[TestCase('2')]
	[TestCase(false)]
	[TestCase(true)]
	public void CharRules_In_InvalidValue(object value)
		=> Assert.That(CharRules.In('A', 'b', '+', '3').Validate(value), Is.False);
}
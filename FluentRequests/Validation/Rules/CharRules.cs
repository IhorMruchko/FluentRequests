using FluentRequests.Lib.Attributes.MetaProgrammingAttributes;
using FluentRequests.Lib.Validation.Base;
using FluentRequests.Lib.Validation.Error;
using System;
using System.Linq;

namespace FluentRequests.Lib.Validation.Rules
{
    public static class CharRules
    {
        //[Convert]
        //[Test(validTestCases: new string[] { "'0'", "'1'", "'2'", "'3'", "'4'", "'5'", "'6'", "'7'", "'8'", "'9'" },
        //      invalidTestCases: new string[] { "'A'", "'b'", "\"S\"", "\"i\"", "true", "false", "1", "1d", "1L", "1f" })]
        //public static Rule<char> IsDigit(Informing state = null)
        //    => new Rule<char>(c => char.IsDigit(c));

        //[Convert]
        //[Test(validTestCases: new string[] { "'^'", "'|'", "'='", "'<'", "'>'", },
        //      invalidTestCases: new string[] { "'1'", "'2'", "true", "1", "1L", })]
        //public static Rule<char> IsSymbol(Informing state = null)
        //    => new Rule<char>(c => char.IsSymbol(c));

        //[Convert]
        //[Test(validTestCases: new string[] { "'A'", "'b'" },
        //    invalidTestCases: new string[] { "'^'", "'|'", "'1'", "'2'", "false", "true" })]
        //public static Rule<char> IsLetter(Informing state = null)
        //    => new Rule<char>(c => char.IsLetter(c));

        //[Convert]
        //[Test(validTestCases: new string[] { "'A'", "'b'", "'+'", "'3'" },
        //      invalidTestCases: new string[] { "'^'", "'|'", "'1'", "'2'", "false", "true" },
        //      initParameters: new string[] { "'A'", "'b'", "'+'", "'3'" })]
        //public static Rule<char> In(params char[] acceptableLetters)
        //    => new Rule<char>(c => acceptableLetters.Contains(c));
    }
}

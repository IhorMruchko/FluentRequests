using FluentRequests.Lib.Attributes.MetaProgrammingAttributes;
using FluentRequests.Lib.Validation.Base;
using FluentRequests.Lib.Validation.Error;
using System;

namespace FluentRequests.Lib.Validation.Rules
{
    public static class BoolRules
    {
        //[Convert]
        //[Test(invalidTestCases:new string[] { "false", "1L", "1", "1f", "1d" },
        //      validTestCases:new string[] { "true" })]
        //public static Rule<bool> IsTrue(Informing state = null)
        //    => new Rule<bool>(b => b);

        //[Convert]
        //[Test(invalidTestCases: new string[] { "true", "1L", "1", "1f", "1d" },
        //      validTestCases: new string[] { "false" })]
        //public static Rule<bool> IsFalse(Informing state = null)
        //    => new Rule<bool>(b => b == false);
    }
}

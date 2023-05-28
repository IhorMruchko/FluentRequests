﻿using FluentRequests.Lib.Attributes.MetaProgrammingAttributes;
using FluentRequests.Lib.Validation.Base;
using FluentRequests.Lib.Validation.Error;
using System;

namespace FluentRequests.Lib.Validation.Rules
{
    public static class IntRules
    {
        [Convert]
        [Test(validTestCases:new string[] {"1", "2", "3", "4", "5"},
              invalidTestCases:new string[] { "-1", "-2", "-3", "-4", "-5" },
              initParameters:new string[] { "0" })]
        [Test(testNumber:1,
              validTestCases: new string[] { "3", "4", "5" },
              invalidTestCases: new string[] { "1", "2", "-1", "-2", "-3", "-4", "-5" },
              initParameters: new string[] { "2" })]
        public static Rule<int> GraterThan(int value, ValidationState state = null)
            => new Rule<int>(v => v > value, state:state);

        [Convert]
        [Test(invalidTestCases: new string[] { "1", "2", "3", "4", "5" },
              validTestCases: new string[] { "-1", "-2", "-3", "-4", "-5" },
              initParameters: new string[] { "0" })]
        public static Rule<int> LessThan(int value, ValidationState state = null)
            => new Rule<int>(v => v < value, state:state);

        [Convert]
        [Test(validTestCases: new string[] { "0", "-1", "-2", "-3", "-4",},
              invalidTestCases: new string[] { "1", "2", "3", "4", "5" },
              initParameters: new string[] { "0" })]
        public static Rule<int> LessOrEqual(int value, ValidationState state = null)
            => LessThan(value).Or(EqualTo(value), state:state);

        [Convert]
        [Test(validTestCases: new string[] { "2",},
              invalidTestCases: new string[] { "-1", "-2", "-3", "-4", "-5", "1", "3", "4", "5" },
              initParameters: new string[] { "2" })]
        public static Rule<int> EqualTo(int value, ValidationState state = null)
            => new Rule<int>(v => v == value, state:state);

        [Convert]
        [Test(validTestCases: new string[] { "2", "3", "4", "5" },
              invalidTestCases: new string[] { "-1", "-2", "-3", "-4", "-5", "1",},
              initParameters: new string[] { "2" })]
        public static Rule<int> GraterOrEqual(int value, ValidationState state = null)
            => GraterThan(value).Or(EqualTo(value), state:state);

        [Convert]
        [Test(validTestCases: new string[] { "3", "4", "5" },
              invalidTestCases: new string[] { "-1", "-2", "-3", "-4", "-5", "1", "11"},
              initParameters: new string[] { "2", "10" })]
        public static Rule<int> Between(int lower, int grater, ValidationState state = null)
            => GraterThan(Math.Min(lower, grater)).And(LessThan(Math.Max(lower, grater)), state:state);

        [Convert]
        [Test(validTestCases: new string[] { "2", "3", "4", "5", "10" },
            invalidTestCases: new string[] { "-1", "-4", "-5", "1", "11" },
            initParameters: new string[] { "2", "10" })]
        public static Rule<int> EqualBetween(int lower, int grater, ValidationState state = null)
          => GraterOrEqual(Math.Min(lower, grater)).And(LessOrEqual(Math.Max(lower, grater)), state:state);
    }
}

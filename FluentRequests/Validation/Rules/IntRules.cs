using FluentRequests.Lib.Attributes.MetaProgrammingAttributes;
using FluentRequests.Lib.Validation.Base;
using FluentRequests.Lib.Validation.Error;
using System;

namespace FluentRequests.Lib.Validation.Rules
{
    public static class IntRules
    {
        [Convert]
        [Test(validTestCases: new string[] { "2", },
            invalidTestCases: new string[] { "-1", "-2", "-3", "-4", "-5", "1", "3", "4", "5" },
            initParameters: new string[] { "2" })]
        public static Rule<int> EqualTo(int value, InformingLevel level = InformingLevel.Ignore)
          => Rule<int>.BeginInit()
                      .FromMethod(v => v == value)
                      .OnLevel(level)
                      .WithConstraint($"Value must be equal to {value}")
                      .WithPropertySelector(v => v.ToString())
                      .EndInit();

        [Convert]
        [Test(validTestCases: new string[] { "1", "2", "3", "4", "5" },
              invalidTestCases: new string[] { "-1", "-2", "-3", "-4", "-5" },
              initParameters: new string[] { "0" })]
        [Test(testNumber: 1,
              validTestCases: new string[] { "3", "4", "5" },
              invalidTestCases: new string[] { "1", "2", "-1", "-2", "-3", "-4", "-5" },
              initParameters: new string[] { "2" })]
        public static Rule<int> GraterThan(int value, InformingLevel level = InformingLevel.Ignore)
            => Rule<int>.BeginInit()
                        .FromMethod(v => v > value)
                        .OnLevel(level)
                        .WithPropertySelector(v => v.ToString())
                        .WithConstraint($"Value must be grater than {value}")
                        .EndInit();

        [Convert]
        [Test(invalidTestCases: new string[] { "1", "2", "3", "4", "5" },
              validTestCases: new string[] { "-1", "-2", "-3", "-4", "-5" },
              initParameters: new string[] { "0" })]
        public static Rule<int> LessThan(int value, InformingLevel level = InformingLevel.Ignore)
            => Rule<int>.BeginInit()
                        .FromMethod(v => v < value)
                        .OnLevel(level)
                        .WithConstraint($"Value must be less than {value}")
                        .WithPropertySelector(v => v.ToString())
                        .EndInit();

        [Convert]
        [Test(validTestCases: new string[] { "0", "-1", "-2", "-3", "-4", },
              invalidTestCases: new string[] { "1", "2", "3", "4", "5" },
              initParameters: new string[] { "0" })]
        public static Rule<int> LessOrEqual(int value, InformingLevel level = InformingLevel.Ignore)
            => LessThan(value, level).InitOperations()
                                     .Or(EqualTo(value, level))
                                     .EndInit();

        [Convert]
        [Test(validTestCases: new string[] { "2", "3", "4", "5" },
              invalidTestCases: new string[] { "-1", "-2", "-3", "-4", "-5", "1", },
              initParameters: new string[] { "2" })]
        public static Rule<int> GraterOrEqual(int value, InformingLevel level = InformingLevel.Ignore)
            => GraterThan(value, level).InitOperations()
                                       .Or(EqualTo(value, level))
                                       .EndInit();

        [Convert]
        [Test(validTestCases: new string[] { "3", "4", "5" },
              invalidTestCases: new string[] { "-1", "-2", "-3", "-4", "-5", "1", "11" },
              initParameters: new string[] { "2", "10" })]
        public static Rule<int> Between(int lower, int grater, InformingLevel level = InformingLevel.Ignore)
            => GraterThan(Math.Min(lower, grater), level).InitOperations()
                                                         .And(LessThan(Math.Max(lower, grater), level))
                                                         .EndInit();

        [Convert]
        [Test(validTestCases: new string[] { "2", "3", "4", "5", "10" },
            invalidTestCases: new string[] { "-1", "-4", "-5", "1", "11" },
            initParameters: new string[] { "2", "10" })]
        public static Rule<int> EqualBetween(int lower, int grater, InformingLevel level = InformingLevel.Ignore)
            => GraterOrEqual(Math.Min(lower, grater), level).InitOperations()
                                                            .And(LessOrEqual(Math.Max(lower, grater), level))
                                                            .EndInit();
        [Convert]
        [Test(validTestCases:new string[] {"0", "2", "7", "13", "24"},
              invalidTestCases:new string[] { "-1", "25", "104", "-404", "505"})]
        public static Rule<int> IsHours(InformingLevel level = InformingLevel.Ignore)
            => EqualBetween(0, 24, level);
    }
}

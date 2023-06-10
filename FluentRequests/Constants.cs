using System.Runtime.CompilerServices;

// [assembly: InternalsVisibleTo("FluentRequest.Console")]

namespace FluentRequests.Lib
{
    internal static class Constants
    {
        public const string AttributesDirectory = @"E:\Programming\C#\FluentRequests\FluentRequests\Attributes\ParameterAttributes\";
        public const string FileExtension = ".cs";
        public const string Pattern = "{0}\r\n\r\nnamespace FluentRequests.Lib.Attributes.ParameterAttributes.{1}Attributes.{7}Attributes\r\n{{\r\n\tpublic class {2}{6}: {6}\r\n\t{{\r\n\t\tpublic {2}{6}({3})\r\n\t\t\t => Rule = {4}({5});\r\n\t}}\r\n}}";

        public const string TestingDirectory = @"E:\Programming\C#\FluentRequests\FluentRequests.Tests\RuleTests\";
        public const string TestPattern = "{0}\r\n\r\nnamespace FluentRequests.Tests.RuleTests;\r\n\r\npublic partial class {1}Test\r\n{{\r\n\t[Test]{2}\r\n\tpublic void {1}_{3}_ValidValue{10}({4})\r\n\t\t=> Assert.That({1}.{3}({9}).Validate({5}), Is.True);\r\n\t\r\n\t[Test]{6}\r\n\tpublic void {1}_{3}_InvalidValue{10}({7})\r\n\t\t=> Assert.That({1}.{3}({9}).Validate({8}), Is.False);\r\n}}";


        public static class Messages
        {
            public const string METHOD_IS_NOT_STATIC = "Method {0} must be static!";
            public const string METHOD_HAS_DIFFERENT_RETURNING_TYPE = "Method {0} must have {1} returning type. Instead {2}.";
        }
    }
}

namespace FluentRequests.Lib
{
    public static class Settings
    {
        public static class Routing
        {
            public static string NoArgumentsProvided { internal get; set; } = "There is no arguments. Use help to find out possible commands";

            public static string BadCommandUsage { internal get; set; } = "Bad usage of the command";

            public static string ReadMoreAboutCommand { internal get; set; } = "Read more about this command";

            public static string NoCommandFinded { internal get; set; } = "There is no such a command. May be you mean";

            public static string OverloadNotFounded { internal get; set; } = "Overload not found for";

            public static string SuggestOverload { internal get; set; } = "Most suitable overload is";

            internal static string BadNaming => BadCommandUsage.Trim(' ', '\n', '\t')
                + " {0}\n"
                + ReadMoreAboutCommand.Trim(' ', '\n', '\t') + "\n" + "{1}";

            internal static string NoCommand => NoCommandFinded.Trim(' ', '\n', '\t') + " {0}.\nMost suitable option is {1}";

            internal static string NoSuitableOverloadFound => OverloadNotFounded + " [{0}]\n" + SuggestOverload + "\n" + "{1}";
        }
    }
}

using FluentRequests.Lib.BuiltInCommands;
using FluentRequests.Lib.Registering;

namespace FluentRequests.Lib.Extensions
{
    public static class RegisterExtensions
    {
        public static Register AddFromType<TCommand>(this Register source)
            => RegistrationManager.AddCommandFromType(typeof(TCommand));

        public static Register AddFromAssembly<TFromAssembly>(this Register source)
            => RegistrationManager.GetRegisterFromAssembly(typeof(TFromAssembly));

        public static Register AddHelpBuiltIn(this Register source) => AddFromType<HelpCommand>(source);

        public static Register AddConsoleBuildIn(this Register source) => AddFromType<ConsoleCommand>(source);

        public static Register AddExitBuildIn(this Register source) => AddFromType<ExitCommand>(source);

    }
}

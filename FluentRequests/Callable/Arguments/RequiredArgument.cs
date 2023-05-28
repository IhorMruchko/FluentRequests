using FluentRequests.Lib.Building.ArgumentBuilding;

namespace FluentRequests.Lib.Callable.Arguments
{
    public class RequiredArgument<TArgument> : Argument<TArgument>
    {
        public static IArgumentNameSetter<RequiredArgument<TArgument>, TArgument> BeginInit()
            => new RequiredArgumentBuilder<TArgument>();

        public override bool Parse()
        {
            return true;
        }
    }
}

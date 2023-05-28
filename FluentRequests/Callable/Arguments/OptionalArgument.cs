using FluentRequests.Lib.Building.ArgumentBuilding;

namespace FluentRequests.Lib.Callable.Arguments
{
    public class OptionalArgument<TArgument> : Argument<TArgument>
    {
        public static IArgumentNameSetter<OptionalArgument<TArgument>, TArgument> BeginInit()
            => new OptionalArgumentBuilder<TArgument>();

        public override bool Parse()
        {
            throw new System.NotImplementedException();
        }
    }
}

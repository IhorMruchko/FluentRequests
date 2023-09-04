using FluentRequests.Lib.Building.ArgumentBuilding;
using FluentRequests.Lib.Extensions;

namespace FluentRequests.Lib.Callable.Arguments
{
    public class RequiredArgument<TArgument> : Argument<TArgument>
    {
        public static IArgumentNameSetter<IArgumentCreator<RequiredArgument<TArgument>, TArgument>, TArgument> BeginInit()
            => new RequiredArgumentBuilder<TArgument>();

        public override string ToString() 
            => $"{typeof(TArgument).CodeName()} {Name}";
    }
}

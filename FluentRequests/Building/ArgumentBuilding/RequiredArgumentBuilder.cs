using FluentRequests.Lib.Callable.Arguments;

namespace FluentRequests.Lib.Building.ArgumentBuilding
{
    public class RequiredArgumentBuilder<TArgument> : 
        ArgumentBuilder<RequiredArgument<TArgument>, TArgument>
    {
        public override RequiredArgument<TArgument> EndInit()
            => new RequiredArgument<TArgument>()
            {
                Name = Name,
                Help = Help,
                Converter = Converter,
                Validation = Validation,
                Constraint = Constraint,
            };
    }
}

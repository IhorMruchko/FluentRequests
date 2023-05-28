using FluentRequests.Lib.Callable.Arguments;

namespace FluentRequests.Lib.Building.ArgumentBuilding
{
    public class OptionalArgumentBuilder<TArgument> : 
        ArgumentBuilder<OptionalArgument<TArgument>, TArgument>
    {
        public override OptionalArgument<TArgument> EndInit() 
            => new OptionalArgument<TArgument>
            {
                Name = Name,
                Help = Help,
                Converter = Converter,
                Validation = Validation,
                Constraint = Constraint,
            };
    }
}

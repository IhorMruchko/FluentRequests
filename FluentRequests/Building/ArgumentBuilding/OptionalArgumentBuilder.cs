using FluentRequests.Lib.Callable.Arguments;

namespace FluentRequests.Lib.Building.ArgumentBuilding
{ 
    public class OptionalArgumentBuilder<TArgument> : 
        ArgumentBuilder<IDefaultValueSetter<TArgument>, OptionalArgument<TArgument>, TArgument>,
        IDefaultValueSetter<TArgument>
    {
        protected TArgument DefaultValue { get; set; }

        public override OptionalArgument<TArgument> EndInit()
            => new OptionalArgument<TArgument>()
            {
                Name = Name,
                Help = Help,
                DefaultValue = DefaultValue,
                Converter = Converter,
                Constraint = Constraint,
                Validation = Validation
            };

        public override IDefaultValueSetter<TArgument> Instatniate()
            => this;

        public IArgumentCreator<OptionalArgument<TArgument>, TArgument> WithDefaultValue(TArgument defaultValue)
        {
            DefaultValue = defaultValue;
            return this;
        }

    }
}

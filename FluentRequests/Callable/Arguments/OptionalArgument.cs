using FluentRequests.Lib.Building.ArgumentBuilding;
using FluentRequests.Lib.Extensions;

namespace FluentRequests.Lib.Callable.Arguments
{
    public class OptionalArgument<TArgument> : Argument<TArgument>
    {
        internal TArgument DefaultValue { get; set; }

        internal override object CurrentValue
        {
            get => TryGetValue(out var result) ? result : DefaultValue;
            set => DefaultValue = (TArgument)value;
        }

        public static IArgumentNameSetter<IDefaultValueSetter<TArgument>, TArgument> BeginInit()
            => new OptionalArgumentBuilder<TArgument>();

        public override string ToString() 
            => $"{typeof(TArgument).CodeName()} {Name} = {DefaultValue}";
    }
}

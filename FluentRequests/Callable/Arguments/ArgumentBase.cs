using FluentRequests.Lib.Validation.Base;

namespace FluentRequests.Lib.Callable.Arguments
{
    public abstract class ArgumentBase
    {
        public string Name { get; internal set; }

        public string Help { get; internal set; }

        internal object Value { get; set; }

        public RuleBase Validation { get; internal set; }

        public RuleBase Constraint { get; internal set; }

        internal virtual object CurrentValue 
        {
            get => Value;
            set => Value = value;
        }

        public abstract bool TryParse(string value);

        public abstract bool Validate();

        public abstract bool FitContraint();

        internal abstract void SetConverter(object converter);

        internal abstract void SetValidator(object validator);

        internal abstract void SetConstraint(object constraint);
    }
}

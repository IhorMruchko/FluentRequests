using FluentRequests.Lib.Callable.Arguments;
using FluentRequests.Lib.Converters;
using FluentRequests.Lib.Validation.Base;
using System;

namespace FluentRequests.Lib.Building.ArgumentBuilding
{
    public abstract class ArgumentBuilder<TArgumentObject, TArgument> 
        : IArgumentNameSetter<TArgumentObject, TArgument>,
          IHelpSetter<IConverterSetter<TArgumentObject, TArgument>>,
          IConstraintSetter<TArgumentObject, TArgument>,
          IConverterSetter<TArgumentObject, TArgument>,
          IArgumentFinalizer<TArgumentObject, TArgument>,
          IRuleBaseSetter<TArgumentObject, TArgument>,
          IValidationOnlySetter<TArgumentObject, TArgument>,
          IConstraintOnlySetter<TArgumentObject, TArgument>
        where TArgumentObject : Argument<TArgument>
    {
        protected string Name { get; set; }

        protected string Help { get; set; }

        protected Converter<string, TArgument> Converter { get; set; }

        protected Rule<TArgument> Constraint { get; set; }

        protected Rule<TArgument> Validation { get; set; }

        public IHelpSetter<IConverterSetter<TArgumentObject, TArgument>> WithName(string name)
        {
            Name = name;
            return this;
        }

        public IConverterSetter<TArgumentObject, TArgument> WithHelp(string helpDescription)
        {
            Help = helpDescription;
            return this;
        }

        public IConstraintSetter<TArgumentObject, TArgument> WithConverter(Converter<string, TArgument> converter)
        {
            Converter = converter;
            return this;
        }

        public IRuleBaseSetter<TArgumentObject, TArgument> UseDefaultConverter()
        {
            Converter = DefaultConverters.GetConverterFor<TArgument>();
            return this;
        }

        public IArgumentFinalizer<TArgumentObject, TArgument> WithValidator(Rule<TArgument> validation)
        {
            Validation = validation;
            return this;
        }
        
        public IArgumentFinalizer<TArgumentObject, TArgument> WithConstraint(Rule<TArgument> constraint)
        {
            Constraint = constraint;
            return this;
        }

        IValidationOnlySetter<TArgumentObject, TArgument> IConstraintSetter<TArgumentObject, TArgument>.WithConstraint(Rule<TArgument> constraint)
        {
            Constraint = constraint;
            return this;
        }

        IRuleBaseSetter<TArgumentObject, TArgument> IConverterSetter<TArgumentObject, TArgument>.WithConverter(Converter<string, TArgument> converter)
        {
            Converter = converter;
            return this;
        }

        IConstraintOnlySetter<TArgumentObject, TArgument> IValidationSetter<TArgumentObject, TArgument>.WithValidator(Rule<TArgument> validation)
        {
            Validation = validation;
            return this;
        }
        public abstract TArgumentObject EndInit();
    }
}

using FluentRequests.Lib.Callable.Arguments;
using FluentRequests.Lib.Converters;
using FluentRequests.Lib.Validation.Base;
using System;

namespace FluentRequests.Lib.Building.ArgumentBuilding
{
    public abstract class ArgumentBuilder<TInitializationState, TArgumentObject, TArgument>
        : IArgumentNameSetter<TInitializationState, TArgument>,
          IHelpSetter<IConverterSetter<TInitializationState, TArgument>>,
          IConstraintSetter<TInitializationState, TArgument>,
          IConverterSetter<TInitializationState, TArgument>,
          IArgumentFinalizer<TInitializationState, TArgument>,
          IRuleBaseSetter<TInitializationState, TArgument>,
          IValidationOnlySetter<TInitializationState, TArgument>,
          IConstraintOnlySetter<TInitializationState, TArgument>,
          IArgumentCreator<TArgumentObject, TArgument>
        where TArgumentObject : Argument<TArgument>
    {
        protected string Name { get; set; }

        protected string Help { get; set; }

        protected Converter<string, TArgument> Converter { get; set; }

        protected Rule<TArgument> Constraint { get; set; }

        protected Rule<TArgument> Validation { get; set; }

        public IHelpSetter<IConverterSetter<TInitializationState, TArgument>> WithName(string name)
        {
            Name = name;
            return this;
        }

        public IConverterSetter<TInitializationState, TArgument> WithHelp(string helpDescription)
        {
            Help = helpDescription;
            return this;
        }

        public IConstraintSetter<TInitializationState, TArgument> WithConverter(Converter<string, TArgument> converter)
        {
            Converter = converter;
            return this;
        }

        public IRuleBaseSetter<TInitializationState, TArgument> UseDefaultConverter()
        {
            Converter = DefaultConverters.GetConverterFor<TArgument>();
            return this;
        }

        public IArgumentFinalizer<TInitializationState, TArgument> WithValidator(Rule<TArgument> validation)
        {
            Validation = validation;
            return this;
        }
        
        public IArgumentFinalizer<TInitializationState, TArgument> WithConstraint(Rule<TArgument> constraint)
        {
            Constraint = constraint;
            return this;
        }

        IValidationOnlySetter<TInitializationState, TArgument> IConstraintSetter<TInitializationState, TArgument>.WithConstraint(Rule<TArgument> constraint)
        {
            Constraint = constraint;
            return this;
        }

        IRuleBaseSetter<TInitializationState, TArgument> IConverterSetter<TInitializationState, TArgument>.WithConverter(Converter<string, TArgument> converter)
        {
            Converter = converter;
            return this;
        }

        IConstraintOnlySetter<TInitializationState, TArgument> IValidationSetter<TInitializationState, TArgument>.WithValidator(Rule<TArgument> validation)
        {
            Validation = validation;
            return this;
        }
        
        public abstract TInitializationState Instatniate();
       
        public abstract TArgumentObject EndInit();
    }
}

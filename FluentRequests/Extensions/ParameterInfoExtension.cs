using FluentRequests.Lib.Attributes.ParameterAttributes;
using FluentRequests.Lib.Attributes.RoutingAttributes;
using FluentRequests.Lib.Building.OverloadBuilding;
using FluentRequests.Lib.Callable.Arguments;
using FluentRequests.Lib.Callable.CallableOverload;
using FluentRequests.Lib.Converters;
using FluentRequests.Lib.Validation.Base;
using System;
using System.Linq;
using System.Reflection;

namespace FluentRequests.Lib.Extensions
{
    public static class ParameterInfoExtension
    {
        public static string IsParams(this ParameterInfo info)
            => info.GetCustomAttributes(typeof(ParamArrayAttribute), false).Length > 0
            ? "params "
            : string.Empty;

        public static string Display(this ParameterInfo info)
            => info.IsOptional
            ? info.ParameterType.CodeName() + " " + info.Name + " = " + 
                (info.HasDefaultValue 
                ? info.ParameterType.IsEnum 
                    ? $"{info.ParameterType.Name}.{info.DefaultValue}"
                    : info.DefaultValue ?? "null"
                : "null")
            : info.IsParams() + info.ParameterType.CodeName() + " " + info.Name;


        public static Overload ToRoutingParameter(this ParameterInfo source, Overload overload)
            => source.IsOptional
            ? source.ToOptionalRoutingParameter(overload)
            : source.ToRequiredRoutingParameter(overload);

        public static Overload ToRequiredRoutingParameter(this ParameterInfo source, Overload overload)
        {
            source.Decompose()
                .Get(p => p.ParameterType, out var parameterType)
                .Get(p => p.GetCustomAttributes<ValidateAttribute>().Select(a => a.Rule).ToArray(), out var validations)
                .Get(p => p.GetCustomAttributes<ConstraintAttribute>().Select(a => a.Rule).ToArray(), out var constraints)
                .Get(p => (ArgumentBase)Activator.CreateInstance(typeof(RequiredArgument<>).MakeGenericType(p.ParameterType)), out var argument);
            
            argument.Name = source.Name;
            argument.Help = source.GetCustomAttribute<HelpAttribute>().Help;
            argument.SetConverter(DefaultConverters.GetConverter(source.ParameterType));
            argument.SetValidator(new AllRule(validations));
            argument.SetConstraint(new AllRule(constraints));
            overload.RequiredArguments.Add(argument);

            return overload;
        }

        public static Overload ToOptionalRoutingParameter(this ParameterInfo source, Overload overload)
        {
            source.Decompose()
               .Get(p => p.ParameterType, out var parameterType)
               .Get(p => p.DefaultValue, out var defaultValue)
               .Get(p => p.GetCustomAttributes<ValidateAttribute>().Select(a => a.Rule).ToArray(), out var validations)
               .Get(p => p.GetCustomAttributes<ConstraintAttribute>().Select(a => a.Rule).ToArray(), out var constraints)
               .Get(p => (ArgumentBase)Activator.CreateInstance(typeof(OptionalArgument<>).MakeGenericType(p.ParameterType)), out var argument);

            argument.Name = source.Name;
            argument.Help = source.GetCustomAttribute<HelpAttribute>().Help;
            argument.SetConverter(DefaultConverters.GetConverter(source.ParameterType));
            argument.SetValidator(new AllRule(validations));
            argument.SetConstraint(new AllRule(constraints));
            overload.OptionalArguments.Add(argument);
            argument.CurrentValue = defaultValue;

            return overload;
        } 
    }
}

using FluentRequests.Lib.Attributes.RoutingAttributes;
using FluentRequests.Lib.Building.CommandBuilding;
using FluentRequests.Lib.Callable.CallableCommand;
using FluentRequests.Lib.Callable.CallableOverload;
using FluentRequests.Lib.Extensions;
using FluentRequests.Lib.Validation.Base;
using FluentRequests.Lib.Validation.Error;
using FluentRequests.Lib.Validation.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FluentRequests.Lib.Registering
{
    public static class RegistrationManager
    {
        private static Register RegisterInstance { get; set; } = new Register();

        public static Register RoutingRegister => RegisterInstance;

        internal static IEnumerable<string> CommandNames => RegisterInstance.Commands.GetAllNames();


        private static readonly Rule<Type> _isValidRegistrationType
            = Rule<Type>.BeginInit()
                        .FromMethod(t => t.GetCustomAttribute<CommandAttribute>() != null)
                        .OnDefaultLevel()
            .And(rb => rb.FromMethod(t => t.GetCustomAttribute<HelpAttribute>() != null)
                         .OnLevel(InformingLevel.Critical)
                         .WithConstraint($"Type declared with {nameof(CommandAttribute)} must contains {nameof(HelpAttribute)}")
                         .WithPropertySelector(t => t.Name)
                         .EndInit())
            .And(rb => rb.FromMethod(t => CommandNames.Contains(t.GetCustomAttribute<CommandAttribute>().CommandName) == false)
                         .OnLevel(InformingLevel.Critical)
                         .WithConstraint("Command name can not be already defined in the register.")
                         .WithPropertySelector(t => t.Name)
                         .EndInit())
            .And(rb => rb.FromMethod(t => t.IsAbstract)
                         .OnLevel(InformingLevel.Error)
                         .WithConstraint($"Type can`t be abstract")
                         .WithPropertySelector(t => t.Name)
                         .Not()
                         .EndInit())
            .And(rb => rb.FromMethod(t => t.IsGenericType)
                         .OnLevel(InformingLevel.Error)
                         .WithConstraint($"Type can`t be generic")
                         .WithPropertySelector(t => t.Name)
                         .Not()
                         .EndInit())
            .EndInit();

        private static readonly Rule<MethodInfo> _isValidRegistrationOverloadsRule
            = MethodInfoRules.ContainsAttribute<OverloadAttribute>()
            .InitOperations()
            .And(MethodInfoRules.ContainsAttribute<HelpAttribute>(InformingLevel.Critical))
            .And(MethodInfoRules.IsPublic(InformingLevel.Critical))
            .And(MethodInfoRules.IsStatic(InformingLevel.Critical))
            .And(rb => rb.FromMethod(m => m.GetParameters().All(p => p.GetCustomAttribute<HelpAttribute>() != null))
                         .OnLevel(InformingLevel.Critical)
                         .WithConstraint($"All parameters of the method must be marked with {nameof(HelpAttribute)}")
                         .WithPropertySelector(m => m.Name)
                         .EndInit())
            .EndInit();


        internal static Register GetRegisterFromAssembly(Type assembly = null)
        {
            var commandTypes = Assembly.GetAssembly(assembly ?? typeof(Register))
                .GetTypes()
                .Where(t => t.IsNested == false && _isValidRegistrationType.ValidateWithError(t))
                .Select(t => GetCommandFromType(t))
                .ToArray();

            foreach (var command in commandTypes)
                RegisterInstance.Add(command);

            return RegisterInstance;
        }

        internal static Register AddCommandFromType(Type target)
        {
            if (_isValidRegistrationType.ValidateWithError(target))
                RegisterInstance.Add(GetCommandFromType(target));
            return RegisterInstance;
        }

        private static Command GetCommandFromType(Type type)
        {
            type.Decompose()
                .Get(t => t.GetCustomAttribute<CommandAttribute>(), out var commandAttribute)
                .Get(t => t.GetCustomAttribute<HelpAttribute>(), out var helpAttribute)
                .Get(t => t.GetNestedTypes().Where(n => _isValidRegistrationType.ValidateWithError(n)).ToArray(), out var nastedTypes)
                .Get(t => t.GetMethods().Where(m => _isValidRegistrationOverloadsRule.ValidateWithError(m)).ToArray(), out var overloads);

            var command = Command.BeginInit()
                .WithName(commandAttribute.CommandName)
                .WithHelp(helpAttribute.Help);

            if (overloads.Any() == false && nastedTypes.Any() == false)
                throw new ArgumentOutOfRangeException($"Class that is marked with {nameof(CommandAttribute)} " +
                    $"must have at least one method marked as {nameof(OverloadAttribute)}");

            foreach (var nastedType in nastedTypes)
            {
                command = command.AddInner(GetCommandFromType(nastedType));
            }

            foreach(var overload in overloads)
            {
                command = command.AddOverload(GetOverloadFromMethod(overload));
            }

            return ((ICommandFinalizer)command).EndInit();           
        }

        private static Overload GetOverloadFromMethod(MethodInfo methodInfo)
        {
            var methodParameters = methodInfo.Decompose()
                                             .Get(m => m.GetCustomAttribute<HelpAttribute>(), out var helpAttribute)
                                             .Get(m => m.GetParameters());

            var overload = Overload.BeginInit()
                .WithHelp(helpAttribute.Help)
                .WithBody(methodInfo.ToRoutingMethod())
                .EndInit();

            foreach(var parameter in methodParameters)
                overload = parameter.ToRoutingParameter(overload);

            return overload;
        }

        public static string Execute(IEnumerable<string> args)
        {
            return RoutingRegister.Execute(args);
        }

        public static async Task<string> ExecuteAsync(IEnumerable<string> args)
        {
            return await RoutingRegister.ExecuteAsync(args);
        }
    }
}

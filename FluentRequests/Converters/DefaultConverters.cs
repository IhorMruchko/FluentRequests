using FluentRequests.Lib.Validation.Base;
using System;
using System.Linq;

namespace FluentRequests.Lib.Converters
{
    public static class DefaultConverters
    {
        private static readonly ArgumentConverterProvider[] _converters;

        private static readonly Rule<Type> _typeRules =
            Rule<Type>.BeginInit()
                      .FromMethod(t => t.IsSubclassOf(typeof(ArgumentConverterProvider)))
                      .OnDefaultLevel()
                      .And(rb => rb.FromMethod(t => t.IsAbstract)
                                  .OnDefaultLevel()
                                  .Not()
                                  .EndInit())
                      .And(rb => rb.FromMethod(t => t.GetConstructor(Type.EmptyTypes) == null)
                                  .OnDefaultLevel()
                                  .Not()
                                  .EndInit())
                      .And(rb => rb.FromMethod(t => t.IsGenericType)
                                   .OnDefaultLevel()
                                   .Not()
                                   .EndInit())
                      .EndInit();

        static DefaultConverters()
        {
            _converters = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => _typeRules.Validate(t))
                .Select(t => (ArgumentConverterProvider)Activator.CreateInstance(t))
                .ToArray();
        }

        public static Converter<string, TResult> GetConverterFor<TResult>()
        {
            var result = _converters.FirstOrDefault(c => c.IsProperType<TResult>());
            return result == null ? null : (Converter<string, TResult>)result.Converter;
        }

        public static object GetConverter(Type type) 
        {
            var result = _converters.FirstOrDefault(c => c.TargetingType == type);
            return result?.Converter;
        }
    }
}

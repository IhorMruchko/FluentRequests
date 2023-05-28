using FluentRequests.Lib.Validation.Base;
using System;
using System.Linq;

namespace FluentRequests.Lib.Converters
{
    public static class DefaultConverters
    {
        private static readonly IArgumentConverter[] _converters;

        private static readonly Rule<Type> _typeRules =
            new NotRule<Type>(t => t.GetInterface(nameof(IArgumentConverter)) == null)
            .And(new NotRule<Type>(t => t.IsGenericType));

        static DefaultConverters()
        {
            _converters = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => _typeRules.Validate(t))
                .Select(t => (IArgumentConverter)Activator.CreateInstance(t))
                .ToArray();
        }

        public static Converter<string, TResult> GetConverterFor<TResult>()
        {
            var result = _converters.FirstOrDefault(c => c.IsCalled<TResult>());
            return result == null ? null : (Converter<string, TResult>)result.Converter;
        }
    }
}

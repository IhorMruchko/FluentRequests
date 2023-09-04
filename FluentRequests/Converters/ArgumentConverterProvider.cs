using System;

namespace FluentRequests.Lib.Converters
{
    public abstract class ArgumentConverterProvider
    {
        public abstract object Converter { get; }

        public abstract Type TargetingType { get; }

        public virtual bool IsProperType<TTarget>() => TargetingType == typeof(TTarget);
        
    }
}

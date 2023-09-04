using FluentRequests.Lib.Validation.Base;
using System;

namespace FluentRequests.Lib.Converters
{
    internal class FloatConverterProvider : ArgumentConverterProvider
    {
        private readonly Rule<string> _isValidFloatNumber =
             Rule<string>.BeginInit()
                        .FromMethod(c => c.EndsWith("f", StringComparison.InvariantCultureIgnoreCase))
                        .OnDefaultLevel()
                        .And(rb => rb.FromMethod(s => s.Replace(",", ".").Split('.').Length <= 2)
                                     .OnDefaultLevel()
                                     .EndInit())
                        .EndInit();

        public override object Converter => new Converter<string, float>(Convert);

        public override Type TargetingType => typeof(float);

        private float Convert(string value)
        {
            if (_isValidFloatNumber.Validate(value))
                return float.Parse(value.Replace('.', ',').TrimEnd('f', 'F'));
            throw new ArgumentException($"Value [{value}] is not in proper float format.", nameof(value));
        }
    }
}

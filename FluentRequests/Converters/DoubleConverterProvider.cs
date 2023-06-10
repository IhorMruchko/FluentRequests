using FluentRequests.Lib.Validation.Base;
using System;

namespace FluentRequests.Lib.Converters
{
    public class DoubleConverterProvider : ArgumentConverterProvider
    {
        private readonly Rule<string> _isValidDoubleNumber =
            Rule<string>.BeginInit()
                        .FromMethod(c => c.EndsWith("d", StringComparison.InvariantCultureIgnoreCase))
                        .OnDefaultLevel()
                        .And(rb => rb.FromMethod(s => s.Replace(",", ".").Split('.').Length <= 2)
                                     .OnDefaultLevel()
                                     .EndInit())
                        .EndInit();

        public override object Converter => new Converter<string, double>(Convert);

        public override Type TargetingType => typeof(double);

        private double Convert(string value)
        {
            if (_isValidDoubleNumber.Validate(value))
                return double.Parse(value.Replace('.', ',').TrimEnd('d', 'D'));
            throw new ArgumentException($"Value [{value}] is not in proper double format.", nameof(value));
        }
    }
}

using FluentRequests.Lib.Validation.Base;
using System;
using System.Linq;

namespace FluentRequests.Lib.Converters
{
    internal class BoolConverterProvider : ArgumentConverterProvider
    {
        private readonly Rule<string> _isBooleanValue =
            Rule<string>.BeginInit()
                        .FromMethod(s => new string[] { "1b", "t", "true" }.Contains(s.ToLower()))
                        .OnDefaultLevel()
                        .EndInit();

        public override object Converter => new Converter<string, bool>(s => _isBooleanValue.Validate(s));

        public override Type TargetingType => typeof(bool);
    }
}

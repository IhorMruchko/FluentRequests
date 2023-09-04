using FluentRequests.Lib.Validation.Base;
using System;
using System.Linq;

namespace FluentRequests.Lib.Converters
{
    internal class BoolConverterProvider : ArgumentConverterProvider
    {
        private readonly Rule<string> _isTrueValue =
            Rule<string>.BeginInit()
                        .FromMethod(s => new string[] { "1b", "t", "true" }.Contains(s.ToLower()))
                        .OnDefaultLevel()
                        .EndInit();

        private readonly Rule<string> _IsFalseValue =
            Rule<string>.BeginInit()
                        .FromMethod(s => new string[] { "0b", "f", "false" }.Contains(s.ToLower()))
                        .OnDefaultLevel()
                        .EndInit();

        public override object Converter => new Converter<string, bool>(s => _isTrueValue.Validate(s) 
        ? true
        : _IsFalseValue.Validate(s)
            ? false
            : throw new Exception());

        public override Type TargetingType => typeof(bool);
    }
}

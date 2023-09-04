using System;

namespace FluentRequests.Lib.Converters
{
    internal class StringConverterProvider : ArgumentConverterProvider
    {
        public override object Converter => new Converter<string, string>(s => s);

        public override Type TargetingType => typeof(string);
    }
}

using System;

namespace FluentRequests.Lib.Converters
{
    public class IntConverterProvider : ArgumentConverterProvider
    {
        public override Type TargetingType => typeof(int);
        
        public override object Converter => new Converter<string, int>((s) => int.Parse(s));
    }
}

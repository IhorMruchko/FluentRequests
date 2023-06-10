using System;

namespace FluentRequests.Lib.Converters
{
    internal class ConsoleColorArgumentConverterProvider : ArgumentConverterProvider
    {
        public override object Converter 
            => new Converter<string, ConsoleColor>(color => (ConsoleColor)Enum.Parse(TargetingType, color, true));

        public override Type TargetingType => typeof(ConsoleColor);
    }
}

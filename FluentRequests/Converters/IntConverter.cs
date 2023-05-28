using System;

namespace FluentRequests.Lib.Converters
{
    public class IntConverter : IArgumentConverter
    {
        public object Converter => new Converter<string, int>((s) => int.Parse(s));

        public bool IsCalled<TResult>() => 1 is TResult;
    }
}

using System.Collections.Generic;
using System.Linq;

namespace FluentRequests.Lib.Callable.Arguments
{
    public abstract class ArgumentBase : ICallable
    {
        public string Name { get; internal set; }

        public string Help { get; internal set; }

        public bool IsCalled(IEnumerable<string> arguments) 
            => Name.Equals(arguments.ElementAt(0)
                                    .TrimStart('-')
                                    .Split('=')[0]);

        // TODO: set returning type to the argument parser state.
        // TODO: Add parameter as argument parser state.
        public abstract bool Parse();
    }
}

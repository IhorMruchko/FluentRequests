using FluentRequests.Lib.Attributes.MetaProgrammingAttributes;
using System.Collections.Generic;

namespace FluentRequests.Lib.Callable
{
    /// <summary>
    /// Defines objects that can be used in the user request routing.
    /// </summary>
    public interface ICallable
    {
        /// <summary>
        /// Defines is <paramref name="arguments"/> list fit the object signature.
        /// </summary>
        /// <param name="arguments">Arguments list that user provides in command prompt 
        /// or text box of the messenger's chat.</param>
        /// <returns>
        /// <c>True</c> - if <paramref name="arguments"/> matches the <see cref="ICallable"/> signature. <br/>
        /// <c>False</c> - otherwise.
        /// </returns>
        bool IsCalled(IEnumerable<string> arguments);
    }
}

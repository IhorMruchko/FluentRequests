using System.Threading.Tasks;

namespace FluentRequests.Lib.Callable
{
    public interface IExecutable
    {
        /// <summary>
        /// Executes <see cref="IExecutable"/> object.
        /// </summary>
        /// <returns>Response for user request as <see cref="string"/>.</returns>
        string Execute();

        /// <summary>
        /// Executes <see cref="IExecutable"/> asynchronously.
        /// </summary>
        /// <returns><see cref="Task{TResult}"/> thats contains a response of the </returns>
        Task<string> ExecuteAsync();
    }
}

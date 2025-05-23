using Models.HandleData;

namespace DbHelper
{
    /// <summary>
    /// Interface for database context service to manage DbContext lifecycle
    /// </summary>
    public interface IDbContextService
    {
        /// <summary>
        /// Execute a database operation that returns a result
        /// </summary>
        Task<T> ExecuteAsync<T>(Func<DAContext, Task<T>> operation);

        /// <summary>
        /// Execute a database operation without return value
        /// </summary>
        Task ExecuteAsync(Func<DAContext, Task> operation);

        /// <summary>
        /// Execute a synchronous database operation that returns a result
        /// </summary>
        T Execute<T>(Func<DAContext, T> operation);

        /// <summary>
        /// Execute a synchronous database operation without return value
        /// </summary>
        void Execute(Action<DAContext> operation);
    }
}

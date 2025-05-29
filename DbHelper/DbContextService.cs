using Microsoft.EntityFrameworkCore;
using Models.HandleData;

namespace DbHelper
{
    /// <summary>
    /// Service implementation for managing DbContext lifecycle and operations
    /// Provides centralized database access with proper resource management
    /// </summary>
    public class DbContextService : IDbContextService
    {
        private readonly IConnectionStringProvider _connectionStringProvider;

        public DbContextService(IConnectionStringProvider connectionStringProvider)
        {
            _connectionStringProvider = connectionStringProvider;
        }

        /// <summary>
        /// Execute an async database operation that returns a result
        /// </summary>
        public async Task<T> ExecuteAsync<T>(Func<DAContext, Task<T>> operation)
        {
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            try
            {
                using var context = CreateContext();
                return await operation(context);
            }
            catch (Exception ex)
            {
                // Log error here if needed
                throw new DatabaseOperationException("Lỗi khi thực hiện thao tác cơ sở dữ liệu", ex);
            }
        }

        /// <summary>
        /// Execute an async database operation without return value
        /// </summary>
        public async Task ExecuteAsync(Func<DAContext, Task> operation)
        {
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            try
            {
                using var context = CreateContext();
                await operation(context);
            }
            catch (Exception ex)
            {
                // Log error here if needed
                throw new DatabaseOperationException("Lỗi khi thực hiện thao tác cơ sở dữ liệu", ex);
            }
        }

        /// <summary>
        /// Execute a synchronous database operation that returns a result
        /// </summary>
        public T Execute<T>(Func<DAContext, T> operation)
        {
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            try
            {
                using var context = CreateContext();
                return operation(context);
            }
            catch (Exception ex)
            {
                // Log error here if needed
                throw new DatabaseOperationException("Lỗi khi thực hiện thao tác cơ sở dữ liệu", ex);
            }
        }

        /// <summary>
        /// Execute a synchronous database operation without return value
        /// </summary>
        public void Execute(Action<DAContext> operation)
        {
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            try
            {
                using var context = CreateContext();
                operation(context);
            }
            catch (Exception ex)
            {
                // Log error here if needed
                throw new DatabaseOperationException("Lỗi khi thực hiện thao tác cơ sở dữ liệu", ex);
            }
        }

        /// <summary>
        /// Create a new DbContext instance with proper configuration
        /// </summary>
        private DAContext CreateContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DAContext>();
            optionsBuilder.UseSqlServer(_connectionStringProvider.GetConnectionString());

            // Add performance optimizations
            optionsBuilder.EnableSensitiveDataLogging(false);
            optionsBuilder.EnableServiceProviderCaching(true);
            optionsBuilder.EnableDetailedErrors(false);

            return new DAContext(optionsBuilder.Options);
        }
    }

    /// <summary>
    /// Interface for providing database connection strings
    /// </summary>
    public interface IConnectionStringProvider
    {
        string GetConnectionString();
    }

    /// <summary>
    /// Default connection string provider
    /// </summary>
    public class DefaultConnectionStringProvider : IConnectionStringProvider
    {
        private readonly string _connectionString;

        public DefaultConnectionStringProvider()
        {
            // Use default connection string
            _connectionString = "Server=.;Database=Tung_DB;Trusted_Connection=True;TrustServerCertificate=True";
        }

        public DefaultConnectionStringProvider(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public string GetConnectionString()
        {
            return _connectionString;
        }
    }

    /// <summary>
    /// Custom exception for database operations
    /// </summary>
    public class DatabaseOperationException : Exception
    {
        public DatabaseOperationException(string message) : base(message) { }
        public DatabaseOperationException(string message, Exception innerException) : base(message, innerException) { }
    }

    /// <summary>
    /// Static factory for creating DbContextService instances
    /// </summary>
    public static class DbContextServiceFactory
    {
        private static IDbContextService? _instance;
        private static readonly object _lock = new object();

        /// <summary>
        /// Get singleton instance of DbContextService
        /// </summary>
        public static IDbContextService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            var connectionProvider = new DefaultConnectionStringProvider();
                            _instance = new DbContextService(connectionProvider);
                        }
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// Create a new instance with custom connection string
        /// </summary>
        public static IDbContextService CreateWithConnectionString(string connectionString)
        {
            var connectionProvider = new DefaultConnectionStringProvider(connectionString);
            return new DbContextService(connectionProvider);
        }

        /// <summary>
        /// Reset singleton instance (for testing purposes)
        /// </summary>
        public static void ResetInstance()
        {
            lock (_lock)
            {
                _instance = null;
            }
        }
    }
}

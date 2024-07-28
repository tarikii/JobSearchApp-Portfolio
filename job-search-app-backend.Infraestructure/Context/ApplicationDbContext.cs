using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace JobSearchApp.Infrastructure.Data
{
    public class ApplicationDbContext
    {
        private readonly ILogger<ApplicationDbContext> _logger;
        private readonly string _azureConnectionString;
        private readonly string _localConnectionString;
        private readonly string _localDbFilePath;

        public ApplicationDbContext(IConfiguration configuration, ILogger<ApplicationDbContext> logger)
        {
            _logger = logger;
            _azureConnectionString = configuration.GetConnectionString("AzureConnection");
            // _localConnectionString = configuration.GetConnectionString("LocalConnection");
            // _localDbFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "JobSearchDb.mdf");
            //
            // EnsureLocalDatabaseExists();
        }

        private void EnsureLocalDatabaseExists()
        {
            if (!File.Exists(_localDbFilePath))
            {
                try
                {
                    var createDbFilePath = _localDbFilePath.Replace(".mdf", ".sql");
                    File.WriteAllText(createDbFilePath, "");

                    using (var connection = new SqlConnection(_localConnectionString))
                    {
                        connection.Open();
                        var createTableCommand = new SqlCommand(File.ReadAllText("CreateTables.sql"), connection);
                        createTableCommand.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while creating the local database file.");
                    throw;
                }
            }
        }

        public SqlConnection GetConnection()
        {
            try
            {
                var connection = new SqlConnection(_azureConnectionString);
                connection.Open();
                _logger.LogInformation("Connection to Azure SQL Database successful.");
                return connection;
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Failed to connect to Azure SQL Database, switching to local database.");

                var localConnection = new SqlConnection(_localConnectionString);
                localConnection.Open();
                _logger.LogInformation("Connection to local SQL Database successful.");
                return localConnection;
            }
        }

        public async Task<string> TestConnectionAsync()
        {
            using (var connection = GetConnection())
            {
                try
                {
                    var command = new SqlCommand("SELECT 1", connection);
                    var result = await command.ExecuteScalarAsync();
                    return result != null ? "Connection test successful." : "Connection test failed.";
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred during connection test.");
                    return "Connection test failed.";
                }
            }
        }
    }
}

using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Data.SqlClient;

namespace DBMigration.Service
{
    public class GraphDataMigrator : DBMigratorBase
    {
        protected override string MigrationDBName => "GraphData";
        private readonly string _currentEnvironment;

        public GraphDataMigrator(IConfiguration configuration) : base(configuration) {
            _currentEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? ENVIRONMENT_DEVELOPMENT;
        }

        private void InitDatabase() {
            if (_currentEnvironment == ENVIRONMENT_DEVELOPMENT) {
                var connection = new SqlConnection(_configuration["DBConfiguration:MasterConnectionString"]);
                connection.Open();

                var command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.Connection = connection;

                command.CommandText = $"DROP DATABASE IF EXISTS {MigrationDBName};";
                command.ExecuteNonQuery();

                command.CommandText = $"CREATE DATABASE {MigrationDBName};";
                command.ExecuteNonQuery();

                connection.Close();
                connection.Dispose();
            }
        }

        public override void Migrate()
        {
            Log.Information($"DBMigration.Service Migrate of {MigrationDBName} is starting its execution.");
            InitDatabase();

            try
            {
                using var connection = new SqlConnection(_configuration["DBConfiguration:GraphDataConnectionString"]);

                var evolve = new Evolve.Evolve(connection, msg => Log.Information(msg))
                {
                    Locations = GetMigrationLocations(_currentEnvironment),
                    IsEraseDisabled = true,
                    EnableClusterMode = true,
                    OutOfOrder = true,
                };

                Log.Information($"DBMigration.Service is now starting the migration process for {MigrationDBName}.");

                evolve.Migrate();

                Log.Information($"DBMigration.Service has completed the migration process for {MigrationDBName}.");
            }
            catch (Exception ex)
            {
                Log.Fatal("DBMigration.Service has failed to migrate with exception {ex}.", ex);
            }

            Log.Information($"DBMigration.Service Migrate of {MigrationDBName} has completed its execution.");
        }
    }
}

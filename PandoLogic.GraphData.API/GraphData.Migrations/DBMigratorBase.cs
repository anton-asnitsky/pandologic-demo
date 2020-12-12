using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace DBMigration.Service
{
    public abstract class DBMigratorBase
    {
        protected const string ENVIRONMENT_PRODUCTION = "Production";
        protected const string ENVIRONMENT_DEVELOPMENT = "Development";

        protected readonly IConfiguration _configuration;

        public DBMigratorBase(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected abstract string MigrationDBName { get; }

        public abstract void Migrate();

        protected IEnumerable<string> GetMigrationLocations(string env)
        {
            var migrationLocations = new List<string>() { $"DB/{env}/{MigrationDBName}/Migrations/" };

            if (!env.Equals(ENVIRONMENT_PRODUCTION, StringComparison.OrdinalIgnoreCase))
                migrationLocations.Add($"DB/{env}/{MigrationDBName}/Seeds/");

            return migrationLocations;
        }
    }
}

using System;
using System.Reflection;
using DbUp;

namespace Snails.Data
{
    public class Migrator : IDbMigrator
    {
        private string _connectionString;

        public Migrator(IDbSettings settings)
        {
            _connectionString = settings.ConnectionString;
        }

        public void Migrate()
        {
            var migrator = DeployChanges.To
                .SqlDatabase(_connectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .Build();

            var result = migrator.PerformUpgrade();

            if (!result.Successful)
            {
                throw new Exception("Database migration failed", result.Error);
            }
        }
    }
}

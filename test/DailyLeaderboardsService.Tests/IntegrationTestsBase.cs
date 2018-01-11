using System;
using System.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;
using toofz.Data;
using toofz.Services.DailyLeaderboardsService.Properties;
using Xunit;

namespace toofz.Services.DailyLeaderboardsService.Tests
{
    [Trait("Category", "Uses SQL Server")]
    [Trait("Category", "Uses file system")]
    [Collection("Uses SQL Server and file system")]
    public abstract class IntegrationTestsBase : IDisposable
    {
        public IntegrationTestsBase()
        {
            settings = Settings.Default;
            // Should only loop once
            foreach (SettingsProvider provider in settings.Providers)
            {
                var ssp = (ServiceSettingsProvider)provider;
                ssp.GetSettingsReader = () => File.OpenText(settingsFileName);
                ssp.GetSettingsWriter = () => File.CreateText(settingsFileName);
            }

            var options = new DbContextOptionsBuilder<NecroDancerContext>()
                .UseSqlServer(databaseConnectionString)
                .Options;

            context = new NecroDancerContext(options);
            context.Database.EnsureDeleted();
            context.Database.Migrate();
        }

        internal readonly Settings settings;
        private readonly string settingsFileName = Path.GetTempFileName();
        protected readonly string databaseConnectionString = StorageHelper.GetDatabaseConnectionString(Constants.NecroDancerContextName);
        protected readonly NecroDancerContext context;

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (File.Exists(settingsFileName)) { File.Delete(settingsFileName); }
                context.Database.EnsureDeleted();
                context.Dispose();
            }
        }
    }
}

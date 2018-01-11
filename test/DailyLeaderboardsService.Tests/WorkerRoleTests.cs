using System;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using Microsoft.ApplicationInsights;
using Moq;
using Ninject;
using Ninject.Extensions.NamedScope;
using toofz.Data;
using toofz.Steam.ClientApi;
using Xunit;

namespace toofz.Services.DailyLeaderboardsService.Tests
{
    public class WorkerRoleTests
    {
        public class IntegrationTests : IntegrationTestsBase
        {
            private readonly Mock<ILog> mockLog = new Mock<ILog>();

            [DisplayFact]
            public async Task ExecutesUpdateCycle()
            {
                // Arrange
                settings.UpdateInterval = TimeSpan.Zero;
                var telemetryClient = new TelemetryClient();
                var runOnce = true;

                var kernel = KernelConfig.CreateKernel();

                kernel.Rebind<string>()
                      .ToConstant(databaseConnectionString)
                      .WhenInjectedInto(typeof(NecroDancerContextOptionsBuilder), typeof(LeaderboardsStoreClient));

                kernel.Rebind<ISteamClientApiClient>()
                      .To<FakeSteamClientApiClient>()
                      .InParentScope();

                using (var context = kernel.Get<NecroDancerContext>())
                {
                    context.EnsureSeedData();
                }

                var log = mockLog.Object;

                // Act
                using (var worker = new WorkerRole(settings, telemetryClient, runOnce, kernel, log))
                {
                    worker.Start();
                    await worker.Completion;
                }

                // Assert
                Assert.True(context.DailyLeaderboards.Any(l => l.LastUpdate != null));
            }
        }
    }
}

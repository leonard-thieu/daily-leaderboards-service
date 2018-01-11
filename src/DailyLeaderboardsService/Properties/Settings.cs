using System.Configuration;

namespace toofz.Services.DailyLeaderboardsService.Properties
{
    [SettingsProvider(typeof(ServiceSettingsProvider))]
    partial class Settings : IDailyLeaderboardsSettings { }
}

namespace toofz.Services.DailyLeaderboardsService.Properties
{
    internal static class IDailyLeaderboardsSettingsExtensions
    {
        /// <summary>
        /// Gets a value indicating if Steam Client credentials are set.
        /// </summary>
        /// <returns>
        /// true, if both <see cref="IDailyLeaderboardsSettings.SteamUserName"/> and <see cref="IDailyLeaderboardsSettings.SteamPassword"/> 
        /// are set; otherwise; false.
        /// </returns>
        public static bool AreSteamClientCredentialsSet(this IDailyLeaderboardsSettings settings)
        {
            return !string.IsNullOrEmpty(settings.SteamUserName) &&
                   settings.SteamPassword != null;
        }
    }
}

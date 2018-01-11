using System;

namespace toofz.Services.DailyLeaderboardsService
{
    internal sealed class DailyLeaderboardsOptions : Options
    {
        /// <summary>
        /// The user name used to log on to Steam.
        /// </summary>
        public string SteamUserName { get; internal set; }
        /// <summary>
        /// The password used to log on to Steam.
        /// </summary>
        public string SteamPassword { get; internal set; } = "";
        /// <summary>
        /// The maxinum number of daily leaderboards to update per cycle.
        /// </summary>
        public int? DailyLeaderboardsPerUpdate { get; internal set; }
        /// <summary>
        /// The amount of time to wait before a request to the Steam Client API times out.
        /// </summary>
        public TimeSpan? SteamClientTimeout { get; internal set; }
    }
}

﻿using SteamKit2;

namespace toofz.Services.DailyLeaderboardsService
{
    internal static class SteamIDExtensions
    {
        public static long ToInt64(this SteamID steamId)
        {
            return (long)(ulong)steamId;
        }
    }
}

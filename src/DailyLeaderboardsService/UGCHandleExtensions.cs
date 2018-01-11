using SteamKit2;

namespace toofz.Services.DailyLeaderboardsService
{
    internal static class UGCHandleExtensions
    {
        public static long? ToReplayId(this UGCHandle ugcHandle)
        {
            return ((ulong)ugcHandle).ToReplayId();
        }
    }
}

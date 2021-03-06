﻿using System.Diagnostics.CodeAnalysis;
using Microsoft.ApplicationInsights.Extensibility.Implementation;

namespace toofz.Services.DailyLeaderboardsService
{
    /// <summary>
    /// Contains extension methods for <see cref="OperationTelemetry"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal static class OperationTelemetryExtensions
    {
        /// <summary>
        /// An exception filter that marks <paramref name="telemetry"/> as unsuccessful.
        /// </summary>
        /// <param name="telemetry">The telemetry item to fail.</param>
        /// <returns>Always returns false.</returns>
        public static bool MarkAsUnsuccessful(this OperationTelemetry telemetry)
        {
            telemetry.Success = false;

            return false;
        }
    }
}

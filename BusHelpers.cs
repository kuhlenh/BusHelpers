using System;
using System.Text;
using System.Text.RegularExpressions;

namespace BusHelpers
{
    public static class BusHelpers
    {
        // Removes the identifier from route name, e.g., ###E for Express routes
        public static string CleanRouteName(string routeShortName) => Regex.Replace(routeShortName, "[^0-9]", "");

        public static string PrintBusInfo(string route, string stop, object time)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Route: {route}\n");
            sb.Append($"StopId: {stop}\n");
            sb.Append($"Arrival Times: {ConvertMillisecondsToUTC(time)}\n");

            return sb.ToString();
        }

        public static DateTime ConvertMillisecondsToUTC(object predictedTimeMS)
        {
            var utcStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var doubleMS = Convert.ToDouble(predictedTimeMS);
            var newTime = utcStart.AddMilliseconds(doubleMS);
            return newTime;
        }
    }
}

using System.Diagnostics;
using System.Globalization;

namespace StevensPassCompanion.Utilities;

public static class DateTimeUtilities
{

    // TODO This is not working! Need to fix and test it!
    public static string ConvertWsdotJsonDateTime(this string dateString)
    {
        try
        {
            // Extract the timestamp and offset
            var match = System.Text.RegularExpressions.Regex.Match(dateString, @"/Date\((\d+)([+-]\d{4})\)/");

            if (match.Success)
            {
                long timestampMilliseconds = long.Parse(match.Groups[1].Value);
                string offsetPart = match.Groups[2].Value;

                // Convert timestamp to UTC DateTime
                DateTime utcDateTime = DateTimeOffset.FromUnixTimeMilliseconds(timestampMilliseconds).UtcDateTime;

                // Parse the offset
                TimeSpan offset = TimeSpan.ParseExact(offsetPart, "hhmm", CultureInfo.InvariantCulture);

                // Adjust for the offset
                DateTime localDateTime = utcDateTime.Add(-offset);

                return localDateTime.ToString();
            }
            else
            {
                Console.WriteLine("Invalid date format.");
            }  
        }
        catch (Exception ex)
        {
            Debug.WriteLine("UnitUtilities.ConvertMetersToFeet - Error - " + ex.Message + ex.StackTrace);
        }

        return dateString;
    }

}

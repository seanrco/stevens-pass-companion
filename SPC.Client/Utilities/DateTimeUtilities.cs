using System.Globalization;

namespace SPC.Client.Utilities;

/// <summary>
/// Static class for DateTime related utility methods.
/// </summary>
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
            Console.Error.WriteLine(ex.Message + ex.StackTrace);
        }

        return dateString;
    }

    /// <summary>
    /// Formats DateTime? obj to specified format.
    /// </summary>
    /// <remarks>
    /// Default format is MM/dd/yyyy h:mm tt unless specified.
    /// </remarks>
    /// <param name="dateTime">DateTime?</param>
    /// <param name="format">string</param>
    /// <returns>string</returns>
    public static string FormatDateTime(this DateTime? dateTime, string format = "MM/dd/yyyy h:mm tt")
    {
        string dateTimeStr = string.Empty;

        try
        {
            if (dateTime != null && dateTime.HasValue)
            {
                dateTimeStr = dateTime.Value.ToString(format);
            }
            else
            {
                Console.Error.WriteLine("DateTime was null or invalid. Unable to format.");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message + ex.StackTrace);
        }

        return dateTimeStr;
    }

    /// <summary>
    /// Formats DateTime obj to specified format.
    /// </summary>
    /// <remarks>
    /// Default format is MM/dd/yyyy h:mm tt unless specified.
    /// </remarks>
    /// <param name="dateTime">DateTime?</param>
    /// <param name="format">string</param>
    /// <returns>string</returns>
    public static string FormatDateTime(this DateTime dateTime, string format = "MM/dd/yyyy h:mm tt")
    {
        return FormatDateTime((DateTime?)dateTime);
    }



}

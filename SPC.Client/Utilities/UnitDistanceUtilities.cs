namespace SPC.Client.Utilities;

/// <summary>
/// Static class for Unit of Distance related utility methods.
/// </summary>
public static class UnitDistanceUtilities
{

    /// <summary>
    /// Converts meters to feet.
    /// </summary>
    /// <param name="meters">float?</param>
    /// <returns>string</returns>
    public static string ConvertMetersToFeet(this float? meters)
    {
        try
        {
            if (meters != null && meters > 0)
            {
                double? feet = (double)meters * 3.28;

                if (feet != null && feet > 0)
                {
                    return Math.Ceiling((decimal)feet).ToString();
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message + ex.StackTrace);
        }

        return "N/A";
    }
}


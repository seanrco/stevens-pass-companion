using System.Diagnostics;

namespace SPC.Client.Utilities;

public static class UnitUtilities
{
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
            Debug.WriteLine("UnitUtilities.ConvertMetersToFeet - Error - " + ex.Message + ex.StackTrace);
        }

        return "N/A";
    }
}


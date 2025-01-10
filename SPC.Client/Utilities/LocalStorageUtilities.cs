using SPC.Core.Models.NOAA.Forecast;

namespace SPC.Client.Utilities;

public static class LocalStorageUtilities
{

    /// <summary>
    /// Adds period to existing saved periods.
    /// </summary>
    /// <param name="period">Period</param>
    /// <param name="savedPeriods">string</param>
    /// <param name="cleanSavedPeriods">bool</param>
    /// <returns>string</returns>
    public static string NoaaAddSavedPeriod(this Period period, string savedPeriods, bool cleanSavedPeriods = true)
    {
        try
        {
            if (!string.IsNullOrEmpty(savedPeriods) || !string.IsNullOrWhiteSpace(savedPeriods))
            {
                if (cleanSavedPeriods)
                {
                    NoaaCleanSavedPeriods(savedPeriods);
                }

                List<string> periods = savedPeriods
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (periods != null && periods.Count > 0 && !periods.Contains(period.StartTime.ToString()))
                {
                    periods.Add(period.StartTime.ToString());

                    return string.Join(",", periods);
                }
            }
            else
            {
                return period.StartTime.ToString();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message + ex.StackTrace);
        }

        return string.Empty;
    }

    /// <summary>
    /// Removes period to existing saved periods.
    /// </summary>
    /// <param name="period">Period</param>
    /// <param name="savedPeriods">string</param>
    /// <param name="cleanSavedPeriods">bool</param>
    /// <returns>string</returns>
    public static string NoaaRemoveSavedPeriod(this Period period, string savedPeriods, bool cleanSavedPeriods = true)
    {
        try
        {
            if (!string.IsNullOrEmpty(savedPeriods) || !string.IsNullOrWhiteSpace(savedPeriods))
            {
                if (cleanSavedPeriods)
                {
                    NoaaCleanSavedPeriods(savedPeriods);
                }

                List<string> periods = savedPeriods
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (periods != null && periods.Count > 0 && periods.Contains(period.StartTime.ToString()))
                {
                    periods.Remove(period.StartTime.ToString());

                    return string.Join(",", periods);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message + ex.StackTrace);
        }

        return string.Empty;
    }

    /// <summary>
    /// Checks period against saved periods.
    /// </summary>
    /// <param name="period">Period</param>
    /// <param name="savedPeriods">string</param>
    /// <param name="cleanSavedPeriods">bool</param>
    /// <returns>string</returns>
    public static bool NoaaCheckSavedPeriod(this Period period, string savedPeriods, bool cleanSavedPeriods = true)
    {
        try
        {
            if (!string.IsNullOrEmpty(savedPeriods) || !string.IsNullOrWhiteSpace(savedPeriods))
            {
                if (cleanSavedPeriods)
                {
                    NoaaCleanSavedPeriods(savedPeriods);
                }

                List<string> periods = savedPeriods
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (periods != null && periods.Count > 0 && periods.Contains(period.StartTime.ToString()))
                {
                    return true;
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message + ex.StackTrace);
        }

        return false;
    }

    /// <summary>
    /// Cleans up past saved periods.
    /// </summary>
    /// <param name="savedPeriods">string</param>
    /// <returns>string</returns>
    private static string NoaaCleanSavedPeriods(string savedPeriods) 
    {
        try
        {
            if (!string.IsNullOrEmpty(savedPeriods) || !string.IsNullOrWhiteSpace(savedPeriods))
            {
                List<string> periods = savedPeriods
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                if (periods != null && periods.Count > 0)
                {
                    foreach (string period in periods.Reverse<string>())
                    {
                        if (DateTime.TryParse(period, out DateTime date))
                        {
                            if (date < DateTime.Now.AddDays(-1))
                            {
                                periods.Remove(period);
                            }
                        }

                    }

                    return string.Join(",", periods);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message + ex.StackTrace);
        }

        return string.Empty;
    }


}

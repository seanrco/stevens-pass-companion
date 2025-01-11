namespace SPC.Infrascructure.Utilities;

public static class AzureUtilities
{

    /// <summary>
    /// Gets Azure function app environment variable value.
    /// </summary>
    /// <remarks>
    /// Info: https://learn.microsoft.com/en-us/azure/azure-functions/functions-dotnet-class-library?tabs=v4%2Ccmd#environment-variables
    /// </remarks>
    /// <param name="name">string</param>
    /// <returns>string</returns>
    public static string GetEnvironmentVariable(string name)
    {
        return Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process) ?? string.Empty;
    }


}

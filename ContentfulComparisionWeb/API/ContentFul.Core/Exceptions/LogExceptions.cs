namespace ContentfulComparisionWeb.ContentFul.Core.Exceptions;
internal class LogExceptions
{
    public static List<string>? ExceptionsData = new List<string>();
    public static void LogException(string Model, string excection)
    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        ExceptionsData.Add(Model + "    :        " + excection);

    }

}

namespace greenlox;

public static class ErrorHandler
{
    public static bool HadError { get; set; } = false;
    public static string ErrorMessage { get; set; } = string.Empty;

    public static void Error(int line, string message)
    {
        Report(line, string.Empty, message);
    }

    public static void Report(int line, string where, string message)
    {
        ErrorMessage = $"[line {line}] Error {where}: {message}";
        HadError = true;
    }
}

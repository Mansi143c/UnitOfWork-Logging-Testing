using Serilog;
public static class LoggingConfig
{
    public static void Configure()
    {
        Log.Logger = new LoggerConfiguration()
        .WriteTo.File("logs/app.log")
        .CreateLogger();
    }
}
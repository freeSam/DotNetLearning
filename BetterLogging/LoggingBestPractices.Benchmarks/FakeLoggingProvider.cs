using Microsoft.Extensions.Logging;

namespace LoggingBestPractices.Benchmarks;

public class FakeLoggingProvider : ILoggerProvider
{
    public void Dispose()
    {

    }

    public ILogger CreateLogger(string categoryName)
    {
        return new FakeLogger();
    }
}

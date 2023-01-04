namespace LoggingBestPractices.Benchmarks;
using Microsoft.Extensions.Logging;


public class FakeLogger : ILogger
{
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {

    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return logLevel != LogLevel.None;
    }

    public IDisposable BeginScope<TState>(TState state)
    {
        return new FakeDisposable();
    }

    private class FakeDisposable : IDisposable
    {
        public void Dispose()
        {
        }
    }
}

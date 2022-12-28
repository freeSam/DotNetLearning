using BenchmarkDotNet.Attributes;

[MemoryDiagnoser()]
public class CoolBenchmark
{
    private const int Day = 26;

    [Benchmark]
    public void SimpleMethod()
    {
        var dayNow = DateTime.Now.Day;
        EnsureThat.ItIsTrue_Simple(dayNow == Day, $"Today wasn't the {Day}th. It was the {dayNow}");
    }

    [Benchmark]
    public void SmartMethod()
    {
        var dayNow = DateTime.Now.Day;
        EnsureThat.ItIsTrue_Smart(dayNow == Day, $"Today wasn't the {Day}th. It was the {dayNow}");
    }
}
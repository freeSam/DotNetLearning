using BenchmarkDotNet.Attributes;
using System.Text;

namespace InterpolatedStringHandlerShowcase;

[MemoryDiagnoser]
public class StringBenchmark
{
    [Benchmark]
    public string BuildDateWithStringConcatenationMethod()
    {
        return string.Concat(1993, "/", 6, "/", 9);
    }

    [Benchmark]
    public string BuildDateWithStringConcatenationMethodToString()
    {
        return string.Concat(1993.ToString(), "/", 6.ToString(), "/", 9.ToString());
    }

    [Benchmark]
    public string BuildDateWithStringConcatenation()
    {
        return 1993 + "/" + 6 + "/" + 9;
    }

    [Benchmark]
    public string BuildDateWithStringBuilder()
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append(1993);
        stringBuilder.Append('/');
        stringBuilder.Append(6);
        stringBuilder.Append('/');
        stringBuilder.Append(9);
        return stringBuilder.ToString();
    }

    [Benchmark]
    public string BuildDateWithOldStringInterpolation()
    {
        return string.Format("{0}/{1}/{2}", 1993, 6, 9);
    }

    [Benchmark]
    public string BuildDateWithNewStringInterpolation()
    {
        return $"{1993}/{6}/{9}";
    }
}

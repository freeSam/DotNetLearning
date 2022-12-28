using BenchmarkDotNet.Attributes;

namespace FixingEnums;

[MemoryDiagnoser(false)]
public class Benchmarks
{
    [Benchmark]
    public string EnumToString()
    {
        return Color.LightGreen.ToString();
    }

    [Benchmark]
    public string EnumToStringFast()
    {
        return Color.LightGreen.ToStringFast();
    }

    [Benchmark]
    public bool EnumIsDefined()
    {
        return Enum.IsDefined(typeof(Color), (Color)69);
    }

    [Benchmark]
    public bool EnumIsDefinedFast()
    {
        return ColorExtensions.IsDefined((Color)69);
    }

    [Benchmark]
    public (bool, Color) EnumTryParse()
    {
        var couldParse = Enum.TryParse("LightGreen", false, out Color value);
        return (couldParse, value);
    }

    [Benchmark]
    public (bool, Color) EnumTryParseFast()
    {
        var couldParse = ColorExtensions.TryParse("LightGreen", false, out Color value);
        return (couldParse, value);
    }
}
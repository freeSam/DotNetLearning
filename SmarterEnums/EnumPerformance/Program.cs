using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using FixingEnums;

BenchmarkRunner.Run<Benchy>();
//BenchmarkRunner.Run<Benchmarks>();

[MemoryDiagnoser]
public class Benchy
{
    [Benchmark]
    public string NativeToString()
    {
        return HumanStates.Dead.ToString();
    }

    [Benchmark]
    public string FastToString()
    {
        return FastToString(HumanStates.Dead);
    }

    private static string FastToString(HumanStates states)
    {
        switch (states)
        {
            case HumanStates.Idle:
                return nameof(HumanStates.Idle);
            case HumanStates.Working:
                return nameof(HumanStates.Working);
            case HumanStates.Sleeping:
                return nameof(HumanStates.Sleeping);
            case HumanStates.Eating:
                return nameof(HumanStates.Eating);
            case HumanStates.Dead:
                return nameof(HumanStates.Dead);
            default:
                throw new ArgumentOutOfRangeException(nameof(states), states, null);
        }
    }
}

public enum HumanStates
{
    Idle,
    Working,
    Sleeping,
    Eating,
    Dead
}
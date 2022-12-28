using BenchmarkDotNet.Attributes;

namespace HashSetVsDictionary;

[MemoryDiagnoser]
public class AddOperationBenchmarks
{
    private Dictionary<string, string> _dictionary = new();
    private HashSet<string> _hashSet = new();

    [Params(10, 100, 1000)]
    public int ItemCount;

    [Benchmark]
    public void Add_Dictionary()
    {
        for (var i = 0; i < ItemCount; i++)
        {
            _dictionary.Add(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
        }
    }

    [Benchmark]
    public void Add_HashSet()
    {
        for (var i = 0; i < ItemCount; i++)
        {
            _hashSet.Add(Guid.NewGuid().ToString());
        }
    }

    [IterationCleanup]
    public void CleanupData()
    {
        _dictionary = new();
        _hashSet = new();
    }
}

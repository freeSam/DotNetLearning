using BenchmarkDotNet.Attributes;

namespace HashSetVsDictionary;

[MemoryDiagnoser]
public class GetOperationBenchmarks
{
    private Dictionary<string, string> _dictionary = new();
    private HashSet<string> _hashSet = new();

    [Params(10, 100, 1000)]
    public int ItemCount;

    private List<KeyValuePair<string, string>> TestValues = new();

    private string _lookupId;

    [GlobalSetup]
    public void Setup()
    {
        for (var i = 0; i < ItemCount; i++)
        {
            TestValues.Add(new KeyValuePair<string, string>(Guid.NewGuid().ToString(), Guid.NewGuid().ToString()));
        }

        _lookupId = TestValues.Select(x => x.Key).Last();

        var keys = TestValues.Select(x => x.Key).ToList();
        var values = TestValues.Select(x => x.Value).ToList();

        for (var i = 0; i < TestValues.Count; i++)
        {
            _dictionary.Add(keys[i], values[i]);
        }

        for (var i = 0; i < ItemCount; i++)
        {
            _hashSet.Add(keys[i]);
        }
    }

    [Benchmark]
    public string Get_Dictionary()
    {
        return _dictionary[_lookupId];
    }

    [Benchmark]
    public string Get_HashSet()
    {
        Func<string, bool> predicate
            = s => s == _lookupId;
        return _hashSet.FirstOrDefault(predicate);
    }

    [GlobalCleanup]
    public void CleanupData()
    {
        _dictionary = new();
        _hashSet = new();
    }
}

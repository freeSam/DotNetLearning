using BenchmarkDotNet.Attributes;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Collections;

namespace DictionaryPerformance;

[MemoryDiagnoser]
public class DictionaryUpdateBenchmarks
{
    private Dictionary<string, string> _dictionary = new();

    private ImmutableDictionary<string, string> _immutableDictionary =
        ImmutableDictionary.Create<string, string>();

    private ConcurrentDictionary<string, string> _concurrentDictionary = new();

    private Hashtable _hashtable = new();

    private static readonly object SyncRoot = new();

    [Params(100, 1000, 10000)]
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
            _immutableDictionary =
                _immutableDictionary.Add(keys[i], values[i]);
        }

        for (var i = 0; i < ItemCount; i++)
        {
            _concurrentDictionary.TryAdd(keys[i], values[i]);
        }

        for (var i = 0; i < ItemCount; i++)
        {
            _hashtable.Add(keys[i], values[i]);
        }
    }

    [Benchmark]
    public void Update_Dictionary()
    {
        _dictionary[_lookupId] = Guid.NewGuid().ToString();
    }

    [Benchmark]
    public void Update_Dictionary_WithLock()
    {
        lock (SyncRoot)
        {
            _dictionary[_lookupId] = Guid.NewGuid().ToString();
        }
    }

    [Benchmark]
    public void Update_ImmutableDictionary()
    {
        _immutableDictionary = _immutableDictionary.SetItem(_lookupId, Guid.NewGuid().ToString());
    }

    [Benchmark]
    public void Update_ConcurrentDictionary()
    {
        _concurrentDictionary[_lookupId] = Guid.NewGuid().ToString();
    }

    [Benchmark]
    public void Update_Hashtable()
    {
        _hashtable[_lookupId] = Guid.NewGuid().ToString();
    }

    [GlobalCleanup]
    public void CleanupData()
    {
        _dictionary = new();
        _immutableDictionary = ImmutableDictionary.Create<string, string>();
        _concurrentDictionary = new();
        _hashtable = new();
    }
}

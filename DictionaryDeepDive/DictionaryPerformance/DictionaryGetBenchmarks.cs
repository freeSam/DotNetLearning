using BenchmarkDotNet.Attributes;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Collections;

namespace DictionaryPerformance;

[MemoryDiagnoser]
public class DictionaryGetBenchmarks
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
    public string Get_Dictionary()
    {
        return _dictionary[_lookupId];
    }

    [Benchmark]
    public string Get_Dictionary_WithLock()
    {
        lock (SyncRoot)
        {
            return _dictionary[_lookupId];
        }
    }

    [Benchmark]
    public string Get_ImmutableDictionary()
    {
        return _immutableDictionary[_lookupId];
    }

    [Benchmark]
    public string Get_ConcurrentDictionary()
    {
        return _concurrentDictionary[_lookupId];
    }

    [Benchmark]
    public string Get_Hashtable()
    {
        return _hashtable[_lookupId]?.ToString()!;
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

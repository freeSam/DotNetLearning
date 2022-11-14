using BenchmarkDotNet.Attributes;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Immutable;

namespace DictionaryPerformance;

[MemoryDiagnoser]
public class DictionaryAddBenchmarks
{
    private Dictionary<string, string> _dictionary = new();

    private ImmutableDictionary<string, string> _immutableDictionary =
        ImmutableDictionary.Create<string, string>();

    private ConcurrentDictionary<string, string> _concurrentDictionary = new();

    private Hashtable _hashtable = new();

    private static readonly object SyncRoot = new();

    [Params(100, 1000, 10000)]
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
    public void Add_Dictionary_WithLock()
    {
        for (var i = 0; i < ItemCount; i++)
        {
            lock (SyncRoot)
            {
                _dictionary.Add(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
            }
        }
    }

    [Benchmark]
    public void Add_ImmutableDictionary()
    {
        for (var i = 0; i < ItemCount; i++)
        {
            _immutableDictionary =
                _immutableDictionary.Add(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
        }
    }

    [Benchmark]
    public void Add_ConcurrentDictionary()
    {
        for (var i = 0; i < ItemCount; i++)
        {
            _concurrentDictionary.TryAdd(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
        }
    }

    [Benchmark]
    public void Add_Hashtable()
    {
        for (var i = 0; i < ItemCount; i++)
        {
            _hashtable.Add(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
        }
    }

    [IterationCleanup]
    public void CleanupData()
    {
        _dictionary = new();
        _immutableDictionary = ImmutableDictionary.Create<string, string>();
        _concurrentDictionary = new();
        _hashtable = new();
    }
}

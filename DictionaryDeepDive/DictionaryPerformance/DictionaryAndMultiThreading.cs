using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Collections;

namespace DictionaryPerformance;

public class DictionaryAndMultiThreading
{
    private Dictionary<int, int> _dictionary = new();
    private Hashtable _hashtable = new();
    private ConcurrentDictionary<int, int> _concurrentDictionary = new();
    private ImmutableDictionary<int, int> _immutableDictionary =
        ImmutableDictionary<int, int>.Empty;

    private readonly Random _random = new(420);
    private const int Count = 1000;

    private static readonly object SyncRoot = new();

    public Dictionary<int, int> Dictionary_Example()
    {
        _ = Enumerable.Range(0, Count)
            .AsParallel()
            .Select(x =>
            {
                lock (SyncRoot)
                {
                    return _dictionary[x] = x;
                }
            })
            .All(i => i >= 0);
        return _dictionary;
    }

    public Hashtable Hashtable_Examples()
    {
        _ = Enumerable.Range(0, Count)
            .AsParallel()
            .Select(x =>
            {
                lock (SyncRoot)
                {
                    return _hashtable[x] = x;
                }
            })
            .All(i => i != null);

        return _hashtable;
    }

    public ConcurrentDictionary<int, int> ConcurrentDictionary_Examples()
    {
        _ = Enumerable.Range(0, Count)
            .AsParallel()
            .Select(x => _concurrentDictionary[x] = x)
            .All(i => i >= 0);
        return _concurrentDictionary;
    }

    public ImmutableDictionary<int, int> ImmutableDictionary_Examples()
    {
        _ = Enumerable.Range(0, Count)
            .AsParallel()
            .Select(x =>
            {
                lock (SyncRoot)
                {
                    return _immutableDictionary = _immutableDictionary.Add(x, x);
                }
            })
            .All(_ => true);
        return _immutableDictionary;
    }
}

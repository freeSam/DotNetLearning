using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Collections;

namespace DictionaryPerformance;

public class DictionaryFeatures
{
    private Dictionary<string, string> _dictionary = new();
    private Hashtable _hashtable = new();
    private ConcurrentDictionary<string, string> _concurrentDictionary = new();
    private ImmutableDictionary<string, string> _immutableDictionary =
        ImmutableDictionary<string, string>.Empty;

    public void Dictionary_Examples()
    {
        _dictionary["name"] = "Nick";

        var name = _dictionary["name"];

        _dictionary["name"] = "Peter";

        _dictionary.Remove("name");
    }

    public void Hashtable_Examples()
    {
        _hashtable.Add("name", "Nick");
        _hashtable.Add("age", 28);

        var age = int.Parse(_hashtable["age"]!.ToString()!);

        _hashtable["age"] = 29;

        _hashtable.Remove("age");
    }

    public void ConcurrentDictionary_Examples()
    {
        _concurrentDictionary["name"] = "Nick";

        var name = _concurrentDictionary["name"];

        _concurrentDictionary["name"] = "Peter";

        _concurrentDictionary.TryRemove("name", out _);
    }

    public void ImmutableDictionary_Examples()
    {
        _immutableDictionary = _immutableDictionary.Add("name", "Nick");

        var name = _immutableDictionary["name"];

        _immutableDictionary = _immutableDictionary.SetItem("name", "Peter");

        _immutableDictionary = _immutableDictionary.Remove("name");
    }
}

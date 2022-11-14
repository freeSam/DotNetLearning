using BenchmarkDotNet.Running;
using DictionaryPerformance;

//var threading = new DictionaryAndMultiThreading();

//var dictionary = threading.Dictionary_Example();
//var hashTable = threading.Hashtable_Examples();
//var immutableDictionary = threading.ImmutableDictionary_Examples();
//var concurrentDictionary = threading.ConcurrentDictionary_Examples();

//return;

BenchmarkRunner.Run<DictionaryAddBenchmarks>();
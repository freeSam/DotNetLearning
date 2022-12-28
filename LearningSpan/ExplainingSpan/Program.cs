using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace ExplainingSpan
{
    class Program
    {
        private static readonly string _dateAsText = "08 07 2021";

        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Benchy>();
            //Console.WriteLine(YearAsText().Slice(2).ToString());
        }

        public static ReadOnlySpan<char> YearAsText()
        {
            ReadOnlySpan<char> dateAsSpan = _dateAsText;
            var yearAsText = dateAsSpan.Slice(6);
            return yearAsText.ToString();
        }
    }

    [MemoryDiagnoser]
    public class Benchy
    {
        private static readonly string _dateAsText = "08 07 2021";

        [Benchmark]
        public (int day, int month, int year) DateWithStringAndSubstring()
        {
            var dayAsText = _dateAsText.Substring(0, 2);
            var monthAsText = _dateAsText.Substring(3, 2);
            var yearAsText = _dateAsText.Substring(6);
            var day = int.Parse(dayAsText);
            var month = int.Parse(monthAsText);
            var year = int.Parse(yearAsText);
            return (day, month, year);
        }

        [Benchmark]
        public (int day, int month, int year) DateWithStringAndSpan()
        {
            ReadOnlySpan<char> dateAsSpan = _dateAsText;
            var dayAsText = dateAsSpan.Slice(0, 2);
            var monthAsText = dateAsSpan.Slice(3, 2);
            var yearAsText = dateAsSpan.Slice(6);
            var day = int.Parse(dayAsText);
            var month = int.Parse(monthAsText);
            var year = int.Parse(yearAsText);
            return (day, month, year);
        }
    }
}
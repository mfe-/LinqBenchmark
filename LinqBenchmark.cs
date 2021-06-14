using System;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace LinqBenchmark
{
    [MemoryDiagnoser]
    public class LinqBenchmark
    {
        public readonly string[] strings;
        public readonly string lookup;
        const int size = 100_000;
        public LinqBenchmark()
        {
            strings = new string[size];
            for (int i = 0; i < size; i++)
            {
                strings[i] = i.ToString();
            }
            Random random = new Random(DateTime.Now.Second);
            lookup = random.Next(0, size).ToString();

        }
        [Benchmark]
        public void FirstOrDefault()
        {
            strings.FirstOrDefault(b => b == lookup);
        }
        [Benchmark]
        public void WhereFirstOrDefault()
        {
            strings.Where(b => b == lookup).FirstOrDefault();
        }
        [Benchmark]
        public void ForLoop()
        {
            for (int i = 0; i < size; i++)
            {
                if (strings[i] == lookup) break;
            }
        }
    }
}
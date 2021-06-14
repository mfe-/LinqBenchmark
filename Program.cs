using System;
using BenchmarkDotNet.Running;

namespace LinqBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            BenchmarkRunner.Run<LinqBenchmark>();
        }


    }
}

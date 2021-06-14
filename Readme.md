# Benchmarks

`dotnet build -c Release`

`dotnet C:\LinqBenchmark\bin\Release\net5.0\LinqBenchmark.dll`

Benchmark testing linq

```csharp
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
```

Results

```console
// * Summary *

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19041.1052 (2004/May2020Update/20H1)
Intel Core i7-6650U CPU 2.20GHz (Skylake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=5.0.203
  [Host]     : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  DefaultJob : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT


|              Method |       Mean |      Error |      StdDev | Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------- |-----------:|-----------:|------------:|------:|------:|------:|----------:|
|      FirstOrDefault | 796.264 us | 37.0373 us | 103.2451 us |     - |     - |     - |      96 B |
| WhereFirstOrDefault |  62.407 us |  0.9699 us |   0.8598 us |     - |     - |     - |     112 B |
|             ForLoop |   3.938 us |  0.1510 us |   0.4283 us |     - |     - |     - |         - |

// * Hints *
Outliers
  LinqBenchmark.FirstOrDefault: Default      -> 10 outliers were removed (1.19 ms..1.57 ms)
  LinqBenchmark.WhereFirstOrDefault: Default -> 3 outliers were removed (65.99 us..89.88 us)
  LinqBenchmark.ForLoop: Default             -> 7 outliers were removed (5.47 us..8.65 us)

// * Legends *
  Mean      : Arithmetic mean of all measurements
  Error     : Half of 99.9% confidence interval
  StdDev    : Standard deviation of all measurements
  Gen 0     : GC Generation 0 collects per 1000 operations
  Gen 1     : GC Generation 1 collects per 1000 operations
  Gen 2     : GC Generation 2 collects per 1000 operations
  Allocated : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
  1 us      : 1 Microsecond (0.000001 sec)

// * Diagnostic Output - MemoryDiagnoser *


// ***** BenchmarkRunner: End *****
// ** Remained 0 benchmark(s) to run **
Run time: 00:03:54 (234.87 sec), executed benchmarks: 3

Global total time: 00:04:01 (241.25 sec), executed benchmarks: 3
// * Artifacts cleanup *
```
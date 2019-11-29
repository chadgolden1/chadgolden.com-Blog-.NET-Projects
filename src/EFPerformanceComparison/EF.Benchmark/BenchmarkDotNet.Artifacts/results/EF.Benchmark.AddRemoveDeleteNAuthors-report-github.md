``` ini

BenchmarkDotNet=v0.12.0, OS=Windows 10.0.17763.864 (1809/October2018Update/Redstone5)
Intel Core i7-8750H CPU 2.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=3.0.101
  [Host]     : .NET Core 3.0.1 (CoreCLR 4.700.19.51502, CoreFX 4.700.19.51609), X64 RyuJIT
  Job-AOEVEE : .NET Core 3.0.1 (CoreCLR 4.700.19.51502, CoreFX 4.700.19.51609), X64 RyuJIT

IterationCount=20  LaunchCount=1  RunStrategy=Throughput  
WarmupCount=5  

```
|                          Method |       Mean |     Error |    StdDev |
|-------------------------------- |-----------:|----------:|----------:|
|                AddNAuthorsToEf6 | 502.874 ms | 5.0854 ms | 5.6524 ms |
|    LoadAndUpdateNAuthorsWithEf6 |   9.948 ms | 0.9484 ms | 0.9739 ms |
|    LoadAndDeleteNAuthorsWithEf6 | 491.388 ms | 4.0540 ms | 4.5060 ms |
|              AddNAuthorToEfCore | 118.911 ms | 5.2810 ms | 5.6506 ms |
| LoadAndUpdateNAuthorsWithEfCore |  29.814 ms | 3.8711 ms | 4.3028 ms |
| LoadAndDeleteNAuthorsWithEfCore | 197.707 ms | 2.3216 ms | 2.5804 ms |

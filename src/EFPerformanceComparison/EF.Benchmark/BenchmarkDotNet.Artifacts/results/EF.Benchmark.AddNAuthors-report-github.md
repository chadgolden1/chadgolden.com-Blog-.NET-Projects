``` ini

BenchmarkDotNet=v0.12.0, OS=Windows 10.0.17763.864 (1809/October2018Update/Redstone5)
Intel Core i7-8750H CPU 2.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=3.0.101
  [Host] : .NET Core 3.0.1 (CoreCLR 4.700.19.51502, CoreFX 4.700.19.51609), X64 RyuJIT


```
|             Method | Mean | Error |
|------------------- |-----:|------:|
|   AddNAuthorsToEf6 |   NA |    NA |
| AddNAuthorToEfCore |   NA |    NA |

Benchmarks with issues:
  AddNAuthors.AddNAuthorsToEf6: DefaultJob
  AddNAuthors.AddNAuthorToEfCore: DefaultJob

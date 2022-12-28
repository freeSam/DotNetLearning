using System;
using System.Diagnostics;
using BenchmarkDotNet.Running;
using InterpolatedStringHandlerShowcase;

//BenchmarkRunner.Run<StringBenchmark>();

BenchmarkRunner.Run<CoolBenchmark>();

//EnsureThat.ItIsTrue(DateTime.Now.Day == 17, $"Today wasn't the {17}");
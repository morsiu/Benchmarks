using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Jobs;
using DotNetPerf.Benchmarks.LogicPackaging.Consumer;

namespace DotNetPerf.Benchmarks.LogicPackaging
{
    [Config(typeof(Config))]
    public class LogicPackagingBenchmark
    {
        private ConsumerStruct<DateTime> _left;
        private ConsumerStruct<DateTime> _right;

        public void Setup()
        {
            _left = new ConsumerStruct<DateTime>(new DateTime(2000, 1, 10), false, new DateTime(2000, 1, 20), true);
            _right = new ConsumerStruct<DateTime>(new DateTime(2000, 1, 15), false, new DateTime(2000, 1, 25), false);
        }
        
        [Benchmark]
        public ConsumerStruct<DateTime> StaticLogic_consumed_by_ConsumerStruct()
        {
            return _left.Intersect(_right);
        }
        
        public sealed class Config : ManualConfig
        {
            public Config()
            {
                Add(new MemoryDiagnoser());
                Add(Job.LegacyJitX86);
                Add(Job.LegacyJitX64);
                Add(Job.RyuJitX64);
            }
        }
    }
}
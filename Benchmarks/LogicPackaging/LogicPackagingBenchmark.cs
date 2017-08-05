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
        private ConsumerStruct<DateTime> _leftStruct;
        private ConsumerStruct<DateTime> _rightStruct;
        private ConsumerStructWithStruct<DateTime> _leftStructWithStruct;
        private ConsumerStructWithStruct<DateTime> _rightStructWithStruct;
        private ConsumerStructWithClass<DateTime> _leftStructWithClass;
        private ConsumerStructWithClass<DateTime> _rightStructWithClass;

        public void Setup()
        {
            _leftStruct = new ConsumerStruct<DateTime>(new DateTime(2000, 1, 10), false, new DateTime(2000, 1, 20), true);
            _rightStruct = new ConsumerStruct<DateTime>(new DateTime(2000, 1, 15), false, new DateTime(2000, 1, 25), false);
            _leftStructWithStruct = new ConsumerStructWithStruct<DateTime>(new DateTime(2000, 1, 10), false, new DateTime(2000, 1, 20), true);
            _rightStructWithStruct = new ConsumerStructWithStruct<DateTime>(new DateTime(2000, 1, 15), false, new DateTime(2000, 1, 25), false);
            _leftStructWithClass = new ConsumerStructWithClass<DateTime>(new DateTime(2000, 1, 10), false, new DateTime(2000, 1, 20), true);
            _rightStructWithClass = new ConsumerStructWithClass<DateTime>(new DateTime(2000, 1, 15), false, new DateTime(2000, 1, 25), false);
        }
        
        [Benchmark]
        public ConsumerStruct<DateTime> Static_method_using_parameters_consumed_by_ConsumerStruct()
        {
            return _leftStruct.IntersectUsingStaticMethodWithParameters(_rightStruct);
        }
        
        [Benchmark]
        public ConsumerStruct<DateTime> Static_method_using_structures_consumed_by_ConsumerStruct()
        {
            return _leftStruct.IntersectUsingStaticMethodWithStructures(_rightStruct);
        }
        
        [Benchmark]
        public ConsumerStruct<DateTime> Static_method_using_classes_consumed_by_ConsumerStruct()
        {
            return _leftStruct.IntersectUsingStaticMethodWithClasses(_rightStruct);
        }
        
        [Benchmark]
        public ConsumerStructWithStruct<DateTime> Static_method_using_structures_consumed_by_ConsumerWithStruct()
        {
            return _leftStructWithStruct.IntersectUsingStaticMethodWithStructures(_rightStructWithStruct);
        }
        
        [Benchmark]
        public ConsumerStructWithClass<DateTime> Static_method_using_classes_consumed_by_ConsumerWithClass()
        {
            return _leftStructWithClass.IntersectUsingStaticMethodWithStructures(_rightStructWithClass);
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
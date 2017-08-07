using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Jobs;
using DotNetPerf.Benchmarks.LogicPackaging.Consumer;
using DotNetPerf.Infrastructure.Columns;

namespace DotNetPerf.Benchmarks.LogicPackaging
{
    [Config(typeof(Config))]
    public class LogicPackagingBenchmark
    {
        private ConsumerStructureWithInlineData<DateTime> _leftInlineStructure;
        private ConsumerStructureWithInlineData<DateTime> _rightInlineStructure;
        private ConsumerStructuctureWithStructure<DateTime> _leftStructureStructure;
        private ConsumerStructuctureWithStructure<DateTime> _rightStructureStructure;
        private ConsumerStructureWithClass<DateTime> _leftClassStructure;
        private ConsumerStructureWithClass<DateTime> _rightClassStructure;
        private ConsumerStructureWithGenericData<DateTime> _leftGenericStructure;
        private ConsumerStructureWithGenericData<DateTime> _rightGenericStructure;

        public void Setup()
        {
            _leftInlineStructure = new ConsumerStructureWithInlineData<DateTime>(new DateTime(2000, 1, 10), false, new DateTime(2000, 1, 20), true);
            _rightInlineStructure = new ConsumerStructureWithInlineData<DateTime>(new DateTime(2000, 1, 15), false, new DateTime(2000, 1, 25), false);
            _leftStructureStructure = new ConsumerStructuctureWithStructure<DateTime>(new DateTime(2000, 1, 10), false, new DateTime(2000, 1, 20), true);
            _rightStructureStructure = new ConsumerStructuctureWithStructure<DateTime>(new DateTime(2000, 1, 15), false, new DateTime(2000, 1, 25), false);
            _leftClassStructure = new ConsumerStructureWithClass<DateTime>(new DateTime(2000, 1, 10), false, new DateTime(2000, 1, 20), true);
            _rightClassStructure = new ConsumerStructureWithClass<DateTime>(new DateTime(2000, 1, 15), false, new DateTime(2000, 1, 25), false);
            _leftGenericStructure = new ConsumerStructureWithGenericData<DateTime>(new DateTime(2000, 1, 10), false, new DateTime(2000, 1, 20), true);
            _rightGenericStructure = new ConsumerStructureWithGenericData<DateTime>(new DateTime(2000, 1, 15), false, new DateTime(2000, 1, 25), false);
        }
        
        [Benchmark]
        public ConsumerStructureWithInlineData<DateTime> Structure__with__inline__store_communicating_with__static_method__inline()
        {
            return _leftInlineStructure.IntersectUsingStaticMethodWithParameters(_rightInlineStructure);
        }
        
        [Benchmark]
        public ConsumerStructureWithInlineData<DateTime> Structure__with__inline__store_communicating_with__static_method__with_structures()
        {
            return _leftInlineStructure.IntersectUsingStaticMethodWithStructures(_rightInlineStructure);
        }
        
        [Benchmark]
        public ConsumerStructureWithInlineData<DateTime> Structure__with__inline__store_communicating_with__static_method__with_classes()
        {
            return _leftInlineStructure.IntersectUsingStaticMethodWithClasses(_rightInlineStructure);
        }
        
        [Benchmark]
        public ConsumerStructuctureWithStructure<DateTime> Structure__with__structure__store_communicating_with__static_method__with_structures()
        {
            return _leftStructureStructure.IntersectUsingStaticMethodWithStructures(_rightStructureStructure);
        }
        
        [Benchmark]
        public ConsumerStructureWithClass<DateTime> Structure__with__class__store_communicating_with__static_method__with_classes()
        {
            return _leftClassStructure.IntersectUsingStaticMethodWithStructures(_rightClassStructure);
        }

        [Benchmark]
        public ConsumerStructureWithGenericData<DateTime> Structure__with__generic_data__store_communicating_with__static_generic_method__with_classes()
        {
            return _leftGenericStructure.IntersectUsingStaticGenericMethodWithClasses(_rightGenericStructure);
        }
        
        public sealed class Config : ManualConfig
        {
            public Config()
            {
                var separators = new[] {"__with__", "__store_communicating_with__", "__"};
                Add(new ChangeId("Consumer", new TagColumn("Consumer", name => new ColumnName(name).NthToken(0, separators))));
                Add(new ChangeId("Consumer store", new TagColumn("Consumer store", name => new ColumnName(name).NthToken(1, separators))));
                Add(new ChangeId("Library", new TagColumn("Library", name => new ColumnName(name).NthToken(2, separators))));
                Add(new ChangeId("Communication", new TagColumn("Communication", name => new ColumnName(name).NthToken(3, separators))));
                Add(new MemoryDiagnoser());
                Add(RPlotExporter.Default);
                Add(CsvMeasurementsExporter.Default);
                //Add(Job.LegacyJitX86);
                Add(Job.LegacyJitX64);
                //Add(Job.RyuJitX64);
            }
        }
    }
}
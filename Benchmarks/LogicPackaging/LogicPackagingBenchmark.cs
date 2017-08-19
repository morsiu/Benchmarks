using System;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using DotNetPerf.Benchmarks.LogicPackaging.Consumer;
using DotNetPerf.Infrastructure.Columns;

namespace DotNetPerf.Benchmarks.LogicPackaging
{
    [Config(typeof(Config))]
    public class LogicPackagingBenchmark
    {
        private ConsumerStructureWithInlineData<DateTime>[] _leftInlineStructure;
        private ConsumerStructureWithInlineData<DateTime>[] _rightInlineStructure;
        private ConsumerStructureWithStructure<DateTime>[] _leftStructureStructure;
        private ConsumerStructureWithStructure<DateTime>[] _rightStructureStructure;
        private ConsumerStructureWithClass<DateTime>[] _leftClassStructure;
        private ConsumerStructureWithClass<DateTime>[] _rightClassStructure;
        private ConsumerStructureWithGenericData<DateTime>[] _leftGenericStructure;
        private ConsumerStructureWithGenericData<DateTime>[] _rightGenericStructure;

        [Params(1, 100, 1000000)]
        public int Count;

        [GlobalSetup]
        public void Setup()
        {
            _leftInlineStructure = Enumerable.Repeat(new ConsumerStructureWithInlineData<DateTime>(new DateTime(2000, 1, 10), false, new DateTime(2000, 1, 20), true), Count).ToArray();
            _rightInlineStructure = Enumerable.Repeat(new ConsumerStructureWithInlineData<DateTime>(new DateTime(2000, 1, 15), false, new DateTime(2000, 1, 25), false), Count).ToArray();
            _leftStructureStructure = Enumerable.Repeat(new ConsumerStructureWithStructure<DateTime>(new DateTime(2000, 1, 10), false, new DateTime(2000, 1, 20), true), Count).ToArray();
            _rightStructureStructure = Enumerable.Repeat(new ConsumerStructureWithStructure<DateTime>(new DateTime(2000, 1, 15), false, new DateTime(2000, 1, 25), false), Count).ToArray();
            _leftClassStructure = Enumerable.Repeat(new ConsumerStructureWithClass<DateTime>(new DateTime(2000, 1, 10), false, new DateTime(2000, 1, 20), true), Count).ToArray();
            _rightClassStructure = Enumerable.Repeat(new ConsumerStructureWithClass<DateTime>(new DateTime(2000, 1, 15), false, new DateTime(2000, 1, 25), false), Count).ToArray();
            _leftGenericStructure = Enumerable.Repeat(new ConsumerStructureWithGenericData<DateTime>(new DateTime(2000, 1, 10), false, new DateTime(2000, 1, 20), true), Count).ToArray();
            _rightGenericStructure = Enumerable.Repeat(new ConsumerStructureWithGenericData<DateTime>(new DateTime(2000, 1, 15), false, new DateTime(2000, 1, 25), false), Count).ToArray();
        }
        
        [Benchmark]
        public void Structure__with__inline__store_communicating_with__static_method__inline()
        {
            for (var i = 0; i < Count; i++)
            {
                _leftInlineStructure[i].IntersectUsingStaticMethodWithParameters(_rightInlineStructure[i]);
            }
        }
        
        [Benchmark]
        public void Structure__with__inline__store_communicating_with__static_method__with_structures()
        {
            for (var i = 0; i < Count; i++)
            {
                _leftInlineStructure[i].IntersectUsingStaticMethodWithStructures(_rightInlineStructure[i]);
            }
        }
        
        [Benchmark]
        public void Structure__with__inline__store_communicating_with__static_method__with_classes()
        {
            for (var i = 0; i < Count; i++)
            {
                _leftInlineStructure[i].IntersectUsingStaticMethodWithClasses(_rightInlineStructure[i]);
            }
        }
        
        [Benchmark]
        public void Structure__with__structure__store_communicating_with__static_method__with_structures()
        {
            for (var i = 0; i < Count; i++)
            {
                _leftStructureStructure[i].IntersectUsingStaticMethodWithStructures(_rightStructureStructure[i]);
            }
        }
        
        [Benchmark]
        public void Structure__with__class__store_communicating_with__static_method__with_classes()
        {
            for (var i = 0; i < Count; i++)
            {
                _leftClassStructure[i].IntersectUsingStaticMethodWithStructures(_rightClassStructure[i]);
            }
        }

        [Benchmark]
        public void Structure__with__generic_data__store_communicating_with__static_generic_method__with_classes()
        {
            for (var i = 0; i < Count; i++)
            {
                _leftGenericStructure[i].IntersectUsingStaticGenericMethodWithClasses(_rightGenericStructure[i]);
            }
        }

        public sealed class Config : BaseConfig
        {
            public Config()
                : base()
            {
                var separators = new[] {"__with__", "__store_communicating_with__", "__"};
                Add(new ChangeId("Consumer", new TagColumn("Consumer", name => new ColumnName(name).NthToken(0, separators))));
                Add(new ChangeId("Consumer store", new TagColumn("Consumer store", name => new ColumnName(name).NthToken(1, separators))));
                Add(new ChangeId("Library", new TagColumn("Library", name => new ColumnName(name).NthToken(2, separators))));
                Add(new ChangeId("Communication", new TagColumn("Communication", name => new ColumnName(name).NthToken(3, separators))));
            }
        }
    }
}
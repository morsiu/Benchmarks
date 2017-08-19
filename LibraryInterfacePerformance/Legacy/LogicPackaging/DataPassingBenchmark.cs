using System;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using LibraryInterfacePerformance.Legacy.LogicPackaging.Consumer;

namespace LibraryInterfacePerformance.Legacy.LogicPackaging
{
    [Config(typeof(BaseConfig))]
    public class DataPassingBenchmark
    {
        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        private static ConsumerStructureWithInlineData<DateTime> LogicInline(
            ConsumerStructureWithInlineData<DateTime> a,
            ConsumerStructureWithInlineData<DateTime> b,
            int depth)
        {
            return depth == 0 ? a.IntersectUsingStaticMethodWithStructures(b) : LogicInline(a, b, depth - 1);
        }
        
        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        private static ConsumerStructureWithInlineData<DateTime> LogicStructure(
            ConsumerStructureWithInlineData<DateTime> a,
            ConsumerStructureWithInlineData<DateTime> b,
            int depth)
        {
            return depth == 0 ? a.IntersectUsingStaticMethodWithStructures(b) : LogicStructure(a, b, depth - 1);
        }
        
        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        private static ConsumerStructureWithInlineData<DateTime> LogicClass(
            ConsumerStructureWithInlineData<DateTime> a,
            ConsumerStructureWithInlineData<DateTime> b,
            int depth)
        {
            return depth == 0 ? a.IntersectUsingStaticMethodWithStructures(b) : LogicClass(a, b, depth - 1);
        }

        [Params(100)]
        public int Depth;

        [Benchmark]
        public ConsumerStructureWithInlineData<DateTime> Inline()
        {
            return LogicInline(
                new ConsumerStructureWithInlineData<DateTime>(new DateTime(2000, 1, 1), true, new DateTime(2000, 1, 10), false),
                new ConsumerStructureWithInlineData<DateTime>(new DateTime(1999, 12, 25), false, new DateTime(2000, 1, 5), true),
                Depth);
        }
        
        [Benchmark]
        public ConsumerStructureWithInlineData<DateTime> Class()
        {
            return LogicClass(
                new ConsumerStructureWithInlineData<DateTime>(new DateTime(2000, 1, 1), true, new DateTime(2000, 1, 10), false),
                new ConsumerStructureWithInlineData<DateTime>(new DateTime(1999, 12, 25), false, new DateTime(2000, 1, 5), true),
                Depth);
        }
        
        [Benchmark]
        public ConsumerStructureWithInlineData<DateTime> Structu()
        {
            return LogicStructure(
                new ConsumerStructureWithInlineData<DateTime>(new DateTime(2000, 1, 1), true, new DateTime(2000, 1, 10), false),
                new ConsumerStructureWithInlineData<DateTime>(new DateTime(1999, 12, 25), false, new DateTime(2000, 1, 5), true),
                Depth);
        }
    }
}
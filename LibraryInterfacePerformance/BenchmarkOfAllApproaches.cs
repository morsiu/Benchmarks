using System;
using BenchmarkDotNet.Attributes;
using LibraryInterfacePerformance.InterfacedStructureInByRef.Consumer;

namespace LibraryInterfacePerformance
{
    [Config(typeof(BenchmarkConfig))]
    public class BenchmarkOfAllApproaches
    {
        internal const string AggregatedStructure = "AggregatedStructure";
        internal const string AggregatedStructureAllByRef = "AggregatedStructureAllByRef";
        internal const string AggregatedStructureInClassAllByRef = "AggregatedStructureInClassAllByRef";
        internal const string AggregatedStructureInByRef = "AggregatedStructureInByRef";
        internal const string InterfacedClass = "InterfacedClass";
        internal const string InterfacedStructure = "InterfacedStructure";
        internal const string InterfacedStructureAllByRef = "InterfacedStructureAllByRef";
        internal const string InterfacedStructuresInByRef = "InterfacedStructuresInByRef";
        internal const string IntermediatePlainValues = "IntermediatePlainValues";
        internal const string IntermediateClass = "IntermediateClass";
        internal const string IntermediateStructure = "IntermediateStructure";

        private IAllBenchmarks _allBenchmarks;
        
        [Params(
            AggregatedStructure,
            AggregatedStructureAllByRef,
            AggregatedStructureInClassAllByRef,
            AggregatedStructureInByRef,
            InterfacedClass,
            InterfacedStructureAllByRef,
            InterfacedStructuresInByRef,
            IntermediateClass,
            IntermediatePlainValues,
            IntermediateStructure)]
        public string ApproachName { get; set; }

        public const int Count = 1_000_000;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _allBenchmarks = ApproachBenchmarks(ApproachName, Count);
        }

        [Benchmark(OperationsPerInvoke = Count)]
        public void RangeIntersection()
        {
            _allBenchmarks.RangeIntersection();
        }

        [Benchmark(OperationsPerInvoke = Count)]
        public bool DoRangesIntersect()
        {
            return _allBenchmarks.DoRangesIntersect();
        }

        private IAllBenchmarks ApproachBenchmarks(string approachName, int rangeCount)
        {
            switch (approachName)
            {
                case AggregatedStructure:
                    return new BenchmarkOfAnApproach<AggregatedStructure.Consumer.Range<int>, AggregatedStructure.Consumer.Ranges<int>>(
                        rangeCount, new AggregatedStructure.Consumer.Ranges<int>());
                case AggregatedStructureAllByRef:
                    return new BenchmarkOfAnApproach<AggregatedStructureAllByRef.Consumer.Range<int>, AggregatedStructureAllByRef.Consumer.Ranges<int>>(
                        rangeCount, new AggregatedStructureAllByRef.Consumer.Ranges<int>());
                case AggregatedStructureInClassAllByRef:
                    return new BenchmarkOfAnApproach<AggregatedStructureInClassAllByRef.Consumer.Range<int>, AggregatedStructureInClassAllByRef.Consumer.Ranges<int>>(
                        rangeCount, new AggregatedStructureInClassAllByRef.Consumer.Ranges<int>());
                case AggregatedStructureInByRef:
                    return new BenchmarkOfAnApproach<AggregatedStructureInByRef.Consumer.Range<int>, AggregatedStructureInByRef.Consumer.Ranges<int>>(
                        rangeCount, new AggregatedStructureInByRef.Consumer.Ranges<int>());
                case InterfacedClass:
                    return new BenchmarkOfAnApproach<InterfacedClass.Consumer.Range<int>, InterfacedClass.Consumer.Ranges<int>>(
                        rangeCount, new InterfacedClass.Consumer.Ranges<int>());
                case InterfacedStructure:
                    return new BenchmarkOfAnApproach<InterfacedStructure.Consumer.Range<int>, InterfacedStructure.Consumer.Ranges<int>>(
                        rangeCount, new InterfacedStructure.Consumer.Ranges<int>());
                case InterfacedStructureAllByRef:
                    return new BenchmarkOfAnApproach<InterfacedStructureAllByRef.Consumer.Range<int>, InterfacedStructureAllByRef.Consumer.Ranges<int>>(
                        rangeCount, new InterfacedStructureAllByRef.Consumer.Ranges<int>());
                case InterfacedStructuresInByRef:
                    return new BenchmarkOfAnApproach<Range<int>, Ranges<int>>(
                        rangeCount, new Ranges<int>());
                case IntermediateClass:
                    return new BenchmarkOfAnApproach<IntermediateClass.Consumer.Range<int>, IntermediateClass.Consumer.Ranges<int>>(
                        rangeCount, new IntermediateClass.Consumer.Ranges<int>());
                case IntermediatePlainValues:
                    return new BenchmarkOfAnApproach<IntermediatePlainValues.Consumer.Range<int>, IntermediatePlainValues.Consumer.Ranges<int>>(
                        rangeCount, new IntermediatePlainValues.Consumer.Ranges<int>());
                case IntermediateStructure: 
                    return new BenchmarkOfAnApproach<IntermediateStructure.Consumer.Range<int>, IntermediateStructure.Consumer.Ranges<int>>(
                        rangeCount, new IntermediateStructure.Consumer.Ranges<int>());
                default : throw new ArgumentOutOfRangeException(nameof(approachName), approachName, "Uknown approach");
            }
        }
    }
}
using System;
using BenchmarkDotNet.Attributes;
using LibraryInterfacePerformance.GenericsAndInterfacesRef.Consumer;

namespace LibraryInterfacePerformance
{
    [Config(typeof(BenchmarkConfig))]
    public class BenchmarkOfAllApproaches
    {
        private const string GenericsAndInterfacesRef = "GenericsAndInterfacesRef";
        private const string GenericsAndInterfacesRefAndReturn = "GenericsAndInterfacesRefAndReturn";
        private const string IntermediatePlainValues = "IntermediatePlainValues";
        private const string AggregatedStructure = "AggregatedStructure";
        private const string AggregatedStructureRef = "AggregatedStructureRef";
        private const string IntermediateClass = "IntermediateClass";
        private const string IntermediateStructure = "IntermediateStructure";

        private IAllBenchmarks _allBenchmarks;
        
        [Params(GenericsAndInterfacesRef, GenericsAndInterfacesRefAndReturn, IntermediatePlainValues, AggregatedStructure, AggregatedStructureRef, IntermediateClass, IntermediateStructure)]
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
                case GenericsAndInterfacesRef:
                    return new BenchmarkOfAnApproach<Range<int>, Ranges<int>>(
                        rangeCount, new Ranges<int>());
                case GenericsAndInterfacesRefAndReturn:
                    return new BenchmarkOfAnApproach<GenericsAndInterfacesRefAndReturn.Consumer.Range<int>, GenericsAndInterfacesRefAndReturn.Consumer.Ranges<int>>(
                        rangeCount, new GenericsAndInterfacesRefAndReturn.Consumer.Ranges<int>());
                case IntermediatePlainValues:
                    return new BenchmarkOfAnApproach<IntermediatePlainValues.Consumer.Range<int>, IntermediatePlainValues.Consumer.Ranges<int>>(
                        rangeCount, new IntermediatePlainValues.Consumer.Ranges<int>());
                case AggregatedStructure:
                    return new BenchmarkOfAnApproach<AggregatedStructure.Consumer.Range<int>, AggregatedStructure.Consumer.Ranges<int>>(
                        rangeCount, new AggregatedStructure.Consumer.Ranges<int>());
                case AggregatedStructureRef:
                    return new BenchmarkOfAnApproach<AggregatedStructure.Consumer.Range<int>, AggregatedStructure.Consumer.Ranges<int>>(
                        rangeCount, new AggregatedStructure.Consumer.Ranges<int>());
                case IntermediateClass:
                    return new BenchmarkOfAnApproach<IntermediateClass.Consumer.Range<int>, IntermediateClass.Consumer.Ranges<int>>(
                        rangeCount, new IntermediateClass.Consumer.Ranges<int>());
                case IntermediateStructure: 
                    return new BenchmarkOfAnApproach<IntermediateStructure.Consumer.Range<int>, IntermediateStructure.Consumer.Ranges<int>>(
                        rangeCount, new IntermediateStructure.Consumer.Ranges<int>());
                default : throw new ArgumentOutOfRangeException(nameof(approachName), approachName, "Uknown approach");
            }
        }
    }
}
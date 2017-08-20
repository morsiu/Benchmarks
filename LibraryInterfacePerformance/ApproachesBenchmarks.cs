using System;
using BenchmarkDotNet.Attributes;

namespace LibraryInterfacePerformance
{
    [Config(typeof(BenchmarkConfig))]
    public class ApproachesBenchmarks
    {
        private IApproachBenchmarks _approachBenchmarks;
        
        [Params("DurableGenerics", "StaticMethods", "StaticMethodsUsingStructures", "TransientClasses", "TransientStructures")]
        public string ApproachName { get; set; }

        public const int Count = 1_000_000;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _approachBenchmarks = ApproachBenchmarks(ApproachName, Count);
        }

        [Benchmark(OperationsPerInvoke = Count)]
        public void RangeIntersection()
        {
            _approachBenchmarks.RangeIntersection();
        }

        [Benchmark(OperationsPerInvoke = Count)]
        public bool DoRangesIntersect()
        {
            return _approachBenchmarks.DoRangesIntersect();
        }

        private IApproachBenchmarks ApproachBenchmarks(string approachName, int rangeCount)
        {
            switch (approachName)
            {
                case "DurableGenerics":
                    return new ApproachBenchmarks<
                            DurableGenerics.Consumer.Range<int>,
                            DurableGenerics.Consumer.Ranges<int>>(
                        rangeCount, new DurableGenerics.Consumer.Ranges<int>());
                case "StaticMethods":
                    return new ApproachBenchmarks<
                            StaticMethods.Consumer.Range<int>,
                            StaticMethods.Consumer.Ranges<int>>(
                        rangeCount, new StaticMethods.Consumer.Ranges<int>());
                case "StaticMethodsUsingStructures":
                    return new ApproachBenchmarks<
                            StaticMethodsUsingStructures.Consumer.Range<int>,
                            StaticMethodsUsingStructures.Consumer.Ranges<int>>(
                        rangeCount, new StaticMethodsUsingStructures.Consumer.Ranges<int>());
                case "TransientClasses":
                    return new ApproachBenchmarks<
                            TransientClasses.Consumer.Range<int>,
                            TransientClasses.Consumer.Ranges<int>>(
                        rangeCount, new TransientClasses.Consumer.Ranges<int>());
                case "TransientStructures": 
                    return new ApproachBenchmarks<
                            TransientStructures.Consumer.Range<int>,
                            TransientStructures.Consumer.Ranges<int>>(
                        rangeCount, new TransientStructures.Consumer.Ranges<int>());
                default : throw new ArgumentOutOfRangeException(nameof(approachName), approachName, "Uknown approach");
            }
        }
    }
}
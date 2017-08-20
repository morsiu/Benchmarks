using System;
using BenchmarkDotNet.Attributes;

namespace LibraryInterfacePerformance
{
    [Config(typeof(BenchmarkConfig))]
    public class BenchmarkOfAllApproaches
    {
        private IAllBenchmarks _allBenchmarks;
        
        [Params("DurableGenerics", "StaticMethods", "StaticMethodsUsingStructures", "TransientClasses", "TransientStructures")]
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
                case "DurableGenerics":
                    return new BenchmarksesOfAnApproach<
                            DurableGenerics.Consumer.Range<int>,
                            DurableGenerics.Consumer.Ranges<int>>(
                        rangeCount, new DurableGenerics.Consumer.Ranges<int>());
                case "StaticMethods":
                    return new BenchmarksesOfAnApproach<
                            StaticMethods.Consumer.Range<int>,
                            StaticMethods.Consumer.Ranges<int>>(
                        rangeCount, new StaticMethods.Consumer.Ranges<int>());
                case "StaticMethodsUsingStructures":
                    return new BenchmarksesOfAnApproach<
                            StaticMethodsUsingStructures.Consumer.Range<int>,
                            StaticMethodsUsingStructures.Consumer.Ranges<int>>(
                        rangeCount, new StaticMethodsUsingStructures.Consumer.Ranges<int>());
                case "TransientClasses":
                    return new BenchmarksesOfAnApproach<
                            TransientClasses.Consumer.Range<int>,
                            TransientClasses.Consumer.Ranges<int>>(
                        rangeCount, new TransientClasses.Consumer.Ranges<int>());
                case "TransientStructures": 
                    return new BenchmarksesOfAnApproach<
                            TransientStructures.Consumer.Range<int>,
                            TransientStructures.Consumer.Ranges<int>>(
                        rangeCount, new TransientStructures.Consumer.Ranges<int>());
                default : throw new ArgumentOutOfRangeException(nameof(approachName), approachName, "Uknown approach");
            }
        }
    }
}
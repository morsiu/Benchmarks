using System.Linq;

namespace LibraryInterfacePerformance
{
    public sealed class BenchmarksesOfAnApproach<TRange, TRanges> : IAllBenchmarks where TRange : IRange<int, TRange>    
        where TRanges : IRanges<int, TRange>
    {
        private readonly RangeIntersectionBenchmark<int, TRange> _rangeIntersectionBenchmark;
        private readonly DoRangesIntersectBenchmark<int, TRange> _doRangesIntersectBenchmark;

        public BenchmarksesOfAnApproach(int rangeCount, TRanges ranges)
        {
            var randomRanges = new RandomRanges<TRange, TRanges>(ranges);
            var firstList = randomRanges.Take(rangeCount).ToArray();
            var secondList = randomRanges.Take(rangeCount).ToArray();
            var resultList = new TRange[rangeCount];
            _rangeIntersectionBenchmark = new RangeIntersectionBenchmark<int, TRange>(firstList, secondList, resultList);
            _doRangesIntersectBenchmark = new DoRangesIntersectBenchmark<int, TRange>(firstList, secondList);
        }

        public bool DoRangesIntersect() => _doRangesIntersectBenchmark.Run();
        
        public void RangeIntersection() => _rangeIntersectionBenchmark.Run();
    }
}
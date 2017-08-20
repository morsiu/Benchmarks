using System;
using System.Collections;
using System.Collections.Generic;

namespace LibraryInterfacePerformance
{
    internal sealed class RandomRanges<TRange, TRanges> : IEnumerable<TRange>
        where TRange : IRange<int, TRange>
        where TRanges : IRanges<int, TRange>
    {
        private const double EmptyRangeProbability = 0.01;
        private const double ClosedStartOrEndProbability = 0.5;
        private readonly TRanges _ranges;
        private readonly Random _random = new Random(1);

        public RandomRanges(TRanges ranges)
        {
            _ranges = ranges;
        }
            
        public IEnumerator<TRange> GetEnumerator()
        {
            while (true)
            {
                if (_random.NextDouble() > EmptyRangeProbability)
                {
                    var start = _random.Next(0, int.MaxValue - 1);
                    var end = _random.Next(start + 1);
                    yield return
                        _ranges.Range(
                            start,
                            _random.NextDouble() > ClosedStartOrEndProbability,
                            end,
                            _random.NextDouble() > ClosedStartOrEndProbability);
                }
                else
                {
                    yield return _ranges.EmptyRange();
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
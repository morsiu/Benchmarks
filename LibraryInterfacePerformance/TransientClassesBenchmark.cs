using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LibraryInterfacePerformance.TransientClasses.Consumer;

namespace LibraryInterfacePerformance
{
    [Config(typeof(BenchmarkConfig))]
    public class TransientClassesBenchmark
    {
        private Range<int>[] _firstList;
        private Range<int>[] _secondList;
        private Range<int>[] _resultList;
        private const int Count = 1_000_000;

        [GlobalSetup]
        public void GlobalSetup()
        {
            var randomRanges = new RandomRanges();
            _firstList = randomRanges.Take(Count).ToArray();
            _secondList = randomRanges.Take(Count).ToArray();
            _resultList = new Range<int>[Count];
        }

        [Benchmark(OperationsPerInvoke = Count)]
        public void IntersectionOfRanges()
        {
            for (var index = 0; index < Count; ++index)
            {
                _resultList[index] = _firstList[index].Intersect(_secondList[index]);
            }
        }

        [Benchmark(OperationsPerInvoke = Count)]
        public bool DoRangesIntersect()
        {
            var result = false;
            for (var index = 0; index < Count; ++index)
            {
                result |= _firstList[index].IntersectsWith(_secondList[index]);
            }
            return result;
        }

        private sealed class RandomRanges : IEnumerable<Range<int>>
        {
            private readonly Random _random1 = new Random(1);
            private readonly Random _random2 = new Random(2);
            private readonly Random _random3 = new Random(3);
            private readonly Random _random4 = new Random(4);
            private readonly Random _random5 = new Random(5);
            
            public IEnumerator<Range<int>> GetEnumerator()
            {
                while (true)
                {
                    if (_random1.NextDouble() > 0.01)
                    {
                        var start = _random2.Next(0, int.MaxValue - 1);
                        var end = _random3.Next(start + 1);
                        yield return
                            new Range<int>(
                                start,
                                _random4.NextDouble() > 0.5,
                                end,
                                _random5.NextDouble() > 0.5);
                    }
                    else
                    {
                        yield return new Range<int>();
                    }
                }
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
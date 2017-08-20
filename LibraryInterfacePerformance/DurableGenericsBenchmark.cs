using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LibraryInterfacePerformance.DurableGenerics.Consumer;

namespace LibraryInterfacePerformance
{
    [Config(typeof(BenchmarkConfig))]
    public class DurableGenericsBenchmark
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
            private readonly Random _random = new Random(1);
            
            public IEnumerator<Range<int>> GetEnumerator()
            {
                while (true)
                {
                    if (_random.NextDouble() > 0.01)
                    {
                        var start = _random.Next(0, int.MaxValue - 1);
                        var end = _random.Next(start + 1);
                        yield return
                            new Range<int>(
                                start,
                                _random.NextDouble() > 0.5,
                                end,
                                _random.NextDouble() > 0.5);
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
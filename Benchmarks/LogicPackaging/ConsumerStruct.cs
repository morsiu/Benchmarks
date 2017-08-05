using System.Collections.Generic;

namespace DotNetPerf.Benchmarks.LogicPackaging
{
    public struct ConsumerStruct<T>
    {
        private readonly T _start;
        private readonly bool _hasOpenStart;
        private readonly T _end;
        private readonly bool _hasOpenEnd;
        private readonly bool _isNotEmpty;

        public ConsumerStruct(T start, bool hasOpenStart, T end, bool hasOpenEnd)
        {
            _start = start;
            _hasOpenStart = hasOpenStart;
            _end = end;
            _hasOpenEnd = hasOpenEnd;
            _isNotEmpty = true;
        }

        public ConsumerStruct<T> Intersect(ConsumerStruct<T> other)
        {
            if (!_isNotEmpty || other._isNotEmpty)
            {
                return new ConsumerStruct<T>();
            }
            StaticLogic.Intersect(
                _start, _hasOpenStart, _end, _hasOpenEnd,
                other._start, other._hasOpenStart, other._end, other._hasOpenEnd,
                out var resultStart, out var resultHasOpenStart, out var resultEnd, out var resultHasOpenEnd,
                Comparer<T>.Default);
            return new ConsumerStruct<T>(resultStart, resultHasOpenStart, resultEnd, resultHasOpenEnd);
        }
    }
}
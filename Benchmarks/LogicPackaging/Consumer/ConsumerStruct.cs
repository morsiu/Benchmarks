using System;
using System.Collections.Generic;
using DotNetPerf.Benchmarks.LogicPackaging.Library;

namespace DotNetPerf.Benchmarks.LogicPackaging.Consumer
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

        public ConsumerStruct<T> IntersectUsingStaticMethodWithParameters(ConsumerStruct<T> other)
        {
            if (!_isNotEmpty || other._isNotEmpty) return new ConsumerStruct<T>();
            StaticMethodsWithInputAndOutputInParameters.Intersect(
                _start, _hasOpenStart, _end, _hasOpenEnd,
                other._start, other._hasOpenStart, other._end, other._hasOpenEnd,
                out var resultStart, out var resultHasOpenStart, out var resultEnd, out var resultHasOpenEnd,
                Comparer<T>.Default);
            return new ConsumerStruct<T>(resultStart, resultHasOpenStart, resultEnd, resultHasOpenEnd);
        }
        
        public ConsumerStruct<T> IntersectUsingStaticMethodWithStructures(ConsumerStruct<T> other)
        {
            if (!_isNotEmpty || other._isNotEmpty) return new ConsumerStruct<T>();
            var result =
                StaticMethodsWithInputAndOutputInStructures.Intersect(
                    new Structure<T>(_start, _hasOpenStart, _end, _hasOpenEnd),
                    new Structure<T>(other._start, other._hasOpenStart, other._end, other._hasOpenEnd),
                    Comparer<T>.Default);
            return result != null
                ? new ConsumerStruct<T>(
                    result.Value.Start, result.Value.HasOpenStart,
                    result.Value.End, result.Value.HasOpenEnd)
                : new ConsumerStruct<T>();
        }

        public ConsumerStruct<T> IntersectUsingStaticMethodWithClasses(ConsumerStruct<T> other)
        {
            if (!_isNotEmpty || other._isNotEmpty) return new ConsumerStruct<T>();
            var result =
                StaticMethodsWithInputAndOutputInClasses.Intersect(
                    new Class<T>(_start, _hasOpenStart, _end, _hasOpenEnd),
                    new Class<T>(other._start, other._hasOpenStart, other._end, other._hasOpenEnd),
                    Comparer<T>.Default);
            return result != null
                ? new ConsumerStruct<T>(
                    result.Start, result.HasOpenStart,
                    result.End, result.HasOpenEnd)
                : new ConsumerStruct<T>();
        }
    }
}
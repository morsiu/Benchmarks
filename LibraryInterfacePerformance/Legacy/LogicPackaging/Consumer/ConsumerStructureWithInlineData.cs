using System;
using System.Collections.Generic;
using LibraryInterfacePerformance.Legacy.LogicPackaging.Library;

namespace LibraryInterfacePerformance.Legacy.LogicPackaging.Consumer
{
    public struct ConsumerStructureWithInlineData<T>
        where T : IComparable<T>
    {
        private readonly T _start;
        private readonly bool _hasOpenStart;
        private readonly T _end;
        private readonly bool _hasOpenEnd;
        private readonly bool _isNotEmpty;

        public ConsumerStructureWithInlineData(T start, bool hasOpenStart, T end, bool hasOpenEnd)
        {
            _start = start;
            _hasOpenStart = hasOpenStart;
            _end = end;
            _hasOpenEnd = hasOpenEnd;
            _isNotEmpty = true;
        }

        public ConsumerStructureWithInlineData<T> IntersectUsingStaticMethodWithParameters(ConsumerStructureWithInlineData<T> other)
        {
            if (!_isNotEmpty || other._isNotEmpty) return new ConsumerStructureWithInlineData<T>();
            StaticMethodsCommunicatingInline.Intersect(
                _start, _hasOpenStart, _end, _hasOpenEnd,
                other._start, other._hasOpenStart, other._end, other._hasOpenEnd,
                out var resultStart, out var resultHasOpenStart, out var resultEnd, out var resultHasOpenEnd,
                Comparer<T>.Default);
            return new ConsumerStructureWithInlineData<T>(resultStart, resultHasOpenStart, resultEnd, resultHasOpenEnd);
        }
        
        public ConsumerStructureWithInlineData<T> IntersectUsingStaticMethodWithStructures(ConsumerStructureWithInlineData<T> other)
        {
            if (!_isNotEmpty || other._isNotEmpty) return new ConsumerStructureWithInlineData<T>();
            var result =
                StaticMethodsCommunicatingWithStructures.Intersect(
                    new Structure<T>(_start, _hasOpenStart, _end, _hasOpenEnd),
                    new Structure<T>(other._start, other._hasOpenStart, other._end, other._hasOpenEnd),
                    Comparer<T>.Default);
            return result != null
                ? new ConsumerStructureWithInlineData<T>(
                    result.Value.Start, result.Value.HasOpenStart,
                    result.Value.End, result.Value.HasOpenEnd)
                : new ConsumerStructureWithInlineData<T>();
        }

        public ConsumerStructureWithInlineData<T> IntersectUsingStaticMethodWithClasses(ConsumerStructureWithInlineData<T> other)
        {
            if (!_isNotEmpty || other._isNotEmpty) return new ConsumerStructureWithInlineData<T>();
            var result =
                StaticMethodsCommunicatingWithClasses.Intersect(
                    new Class<T>(_start, _hasOpenStart, _end, _hasOpenEnd),
                    new Class<T>(other._start, other._hasOpenStart, other._end, other._hasOpenEnd),
                    Comparer<T>.Default);
            return result != null
                ? new ConsumerStructureWithInlineData<T>(
                    result.Start, result.HasOpenStart,
                    result.End, result.HasOpenEnd)
                : new ConsumerStructureWithInlineData<T>();
        }

        public ConsumerStructureWithInlineData<T> IntersectUsingInstanceMethodWithStructures(ConsumerStructureWithInlineData<T> other)
        {
            if (!_isNotEmpty || other._isNotEmpty) return new ConsumerStructureWithInlineData<T>();
            var result =
                new StructureWithMethods<T>(_start, _hasOpenStart, _end, _hasOpenEnd).Intersect(
                    new StructureWithMethods<T>(other._start, other._hasOpenStart, other._end, other._hasOpenEnd));
            return result != null
                ? new ConsumerStructureWithInlineData<T>(result.Value.Start,  result.Value.HasOpenStart, result.Value.End, result.Value.HasOpenEnd)
                : new ConsumerStructureWithInlineData<T>();
        }
        
        public ConsumerStructureWithInlineData<T> IntersectUsingInstanceMethodWithClasses(ConsumerStructureWithInlineData<T> other)
        {
            if (!_isNotEmpty || other._isNotEmpty) return new ConsumerStructureWithInlineData<T>();
            var result =
                new ClassWithMethods<T>(_start, _hasOpenStart, _end, _hasOpenEnd).Intersect(
                    new ClassWithMethods<T>(other._start, other._hasOpenStart, other._end, other._hasOpenEnd));
            return result != null
                ? new ConsumerStructureWithInlineData<T>(result.Start,  result.HasOpenStart, result.End, result.HasOpenEnd)
                : new ConsumerStructureWithInlineData<T>();
        }
    }
}
using System;
using Impl = LibraryInterfacePerformance.StaticMethodsUsingStructures.Library;

namespace LibraryInterfacePerformance.StaticMethodsUsingStructures.Consumer
{
    public struct Range<T> : IRange<T, Range<T>>
        where T : IComparable<T>
    {
        private Impl.Range<T> _impl;

        public Range(T start, bool openStart, T end, bool openEnd)
        {
            _impl = new Impl.Range<T>(start, openStart, end, openEnd);
        }

        public bool IntersectsWith(Range<T> other) =>
            Impl.RangeOperations.IntersectsWith(
                ref _impl,
                ref other._impl);

        public Range<T> Intersect(Range<T> other)
        {
            var result = new Range<T>();
            Impl.RangeOperations.Intersect(
                ref _impl,
                ref other._impl,
                ref result._impl);
            return result;
        }
    }
}
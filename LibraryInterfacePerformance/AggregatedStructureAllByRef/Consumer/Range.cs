using System;
using LibraryInterfacePerformance.AggregatedStructureAllByRef.Library;

namespace LibraryInterfacePerformance.AggregatedStructureAllByRef.Consumer
{
    public struct Range<T> : IRange<T, Range<T>>
        where T : IComparable<T>
    {
        private Library.Range<T> _impl;

        public Range(T start, bool openStart, T end, bool openEnd)
        {
            _impl = new Library.Range<T>(start, openStart, end, openEnd);
        }

        public bool IntersectsWith(Range<T> other) =>
            RangeOperations.IntersectsWith(
                ref _impl,
                ref other._impl);

        public Range<T> Intersect(Range<T> other)
        {
            var result = new Range<T>();
            RangeOperations.Intersect(
                ref _impl,
                ref other._impl,
                ref result._impl);
            return result;
        }
    }
}
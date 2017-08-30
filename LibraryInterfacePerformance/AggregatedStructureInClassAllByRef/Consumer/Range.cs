using System;

namespace LibraryInterfacePerformance.AggregatedStructureInClassAllByRef.Consumer
{
    public sealed class Range<T> : IRange<T, Range<T>>
        where T : IComparable<T>
    {
        private Library.Range<T> _impl;

        public Range()
        {
        }

        public Range(T start, bool openStart, T end, bool openEnd)
        {
            _impl = new Library.Range<T>(start, openStart, end, openEnd);
        }
        
        public bool IntersectsWith(Range<T> other) =>
            Library.RangeOperations.IntersectsWith(
                ref _impl,
                ref other._impl);

        public Range<T> Intersect(Range<T> other)
        {
            var result = new Range<T>();
            Library.RangeOperations.Intersect(
                ref _impl,
                ref other._impl,
                out result._impl);
            return result;
        }
    }
}
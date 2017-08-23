using System;
using LibraryInterfacePerformance.AggregatedStructureInByRef.Library;

namespace LibraryInterfacePerformance.AggregatedStructureInByRef.Consumer
{
    public struct Range<T> : IRange<T, Range<T>>
        where T : IComparable<T>
    {
        private Library.Range<T> _implementation;

        public Range(T start, bool openStart, T end, bool openEnd)
        {
            _implementation = new Library.Range<T>(start, openStart, end, openEnd);
        }

        private Range(Library.Range<T> implementation)
        {
            _implementation = implementation;
        }

        public bool IntersectsWith(Range<T> other) =>
            RangeOperations.IntersectsWith(
                ref _implementation,
                ref other._implementation);

        public Range<T> Intersect(Range<T> other)
        {
            return new Range<T>(
                RangeOperations.Intersect(
                    ref _implementation,
                    ref other._implementation));
        }
    }
}
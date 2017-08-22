using System;
using Impl = LibraryInterfacePerformance.AggregatedStructureRefAndReturn.Library;

namespace LibraryInterfacePerformance.AggregatedStructureRefAndReturn.Consumer
{
    public struct Range<T> : IRange<T, Range<T>>
        where T : IComparable<T>
    {
        private Impl.Range<T> _implementation;

        public Range(T start, bool openStart, T end, bool openEnd)
        {
            _implementation = new Impl.Range<T>(start, openStart, end, openEnd);
        }

        private Range(Impl.Range<T> implementation)
        {
            _implementation = implementation;
        }

        public bool IntersectsWith(Range<T> other) =>
            Impl.RangeOperations.IntersectsWith(
                ref _implementation,
                ref other._implementation);

        public Range<T> Intersect(Range<T> other)
        {
            return new Range<T>(
                Impl.RangeOperations.Intersect(
                    ref _implementation,
                    ref other._implementation));
        }
    }
}
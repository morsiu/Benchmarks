using System;
using Impl = LibraryInterfacePerformance.AggregatedStructure.Library;

namespace LibraryInterfacePerformance.AggregatedStructure.Consumer
{
    public struct Range<T> : IRange<T, Range<T>>
        where T : IComparable<T>
    {
        private readonly Impl.Range<T> _implementation;

        public Range(T start, bool openStart, T end, bool openEnd)
        {
            _implementation = new Impl.Range<T>(start, openStart, end, openEnd);
        }

        private Range(Impl.Range<T> implementation)
        {
            _implementation = implementation;
        }

        public bool Empty => _implementation.Empty;
        public bool OpenStart => _implementation.OpenStart;
        public bool OpenEnd => _implementation.OpenEnd;

        public bool IntersectsWith(Range<T> other) =>
            _implementation.IntersectsWith(other._implementation);

        public Range<T> Intersect(Range<T> other) =>
            new Range<T>(_implementation.Intersect(other._implementation));
    }
}
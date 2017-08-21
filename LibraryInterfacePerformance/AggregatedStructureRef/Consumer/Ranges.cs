using System;

namespace LibraryInterfacePerformance.AggregatedStructureRef.Consumer
{
    public struct Ranges<T> : IRanges<T, Range<T>>
        where T : IComparable<T>
    {
        public Range<T> EmptyRange() =>
            new Range<T>();

        public Range<T> Range(T start, bool openStart, T end, bool openEnd) =>
            new Range<T>(start, openStart, end, openEnd);
    }
}
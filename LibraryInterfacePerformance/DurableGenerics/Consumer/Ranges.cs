using System;
using LibraryInterfacePerformance.DurableGenerics.Library;

namespace LibraryInterfacePerformance.DurableGenerics.Consumer
{
    public struct Ranges<T> : IRanges<T, Range<T>>
        where T : IComparable<T>
    {
        public Range<T> Range(T start, bool openStart, T end, bool openEnd)
        {
            return new Range<T>(start, openStart, end, openEnd);
        }

        public Range<T> EmptyRange()
        {
            return new Range<T>();
        }
    }
}
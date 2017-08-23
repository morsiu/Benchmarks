using System;

namespace LibraryInterfacePerformance.InterfacedClass.Consumer
{
    public struct Ranges<T> : Library.IRanges<T, Range<T>>, IRanges<T, Range<T>>
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
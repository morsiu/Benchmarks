using System;

namespace LibraryInterfacePerformance
{
    public interface IRanges<in T, out TRange>
        where T : IComparable<T>
        where TRange : IRange<T, TRange>
    {
        TRange EmptyRange();
        TRange Range(T start, bool openStart, T end, bool openEnd);
    }
}
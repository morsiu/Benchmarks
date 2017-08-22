using System;

namespace LibraryInterfacePerformance.GenericsAndInterfacesRef.Library
{
    public interface IRanges<in T, out TRange>
        where T : IComparable<T>
        where TRange : IRange<T>
    {
        TRange Range(T start, bool openStart, T end, bool openEnd);
        TRange EmptyRange();
    }
}
using System;

namespace LibraryInterfacePerformance
{
    public interface IRange<in T, TRange>
        where T : IComparable<T>
        where TRange : IRange<T, TRange>
    {
        TRange Intersect(TRange other);

        bool IntersectsWith(TRange other);
    }
}
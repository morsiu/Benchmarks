using System;

namespace LibraryInterfacePerformance.GenericsAndInterfacesRefRangesDefault.Library
{
    public interface IRange<out T>
        where T : IComparable<T>
    {
        T Start { get; }
        T End { get; }
        bool OpenStart { get; }
        bool OpenEnd { get; }
        bool Empty { get; }
    }
}
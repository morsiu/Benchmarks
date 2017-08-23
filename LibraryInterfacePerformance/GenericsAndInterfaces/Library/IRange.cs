using System;

namespace LibraryInterfacePerformance.GenericsAndInterfaces.Library
{
    public interface IRange<T>
        where T : IComparable<T>
    {
        T Start { get; }
        T End { get; }
        bool OpenStart { get; }
        bool OpenEnd { get; }
        bool Empty { get; }
    }
}
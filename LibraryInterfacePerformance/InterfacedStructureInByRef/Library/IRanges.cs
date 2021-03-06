﻿using System;

namespace LibraryInterfacePerformance.InterfacedStructureInByRef.Library
{
    public interface IRanges<T, TRange>
        where T : IComparable<T>
        where TRange : IRange<T>
    {
        TRange Range(T start, bool openStart, T end, bool openEnd);
        TRange EmptyRange();
    }
}
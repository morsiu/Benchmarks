﻿using System;
using Impl = LibraryInterfacePerformance.InterfacedStructure.Library;

namespace LibraryInterfacePerformance.InterfacedStructure.Consumer
{
    public struct Ranges<T> : Impl.IRanges<T, Range<T>>, IRanges<T, Range<T>>
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
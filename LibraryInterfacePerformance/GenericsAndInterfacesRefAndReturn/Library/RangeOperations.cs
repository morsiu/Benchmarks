﻿using System;

namespace LibraryInterfacePerformance.GenericsAndInterfacesRefAndReturn.Library
{
    public static class RangeOperations
    {
        public static bool Intersect<T, TRange, TRanges>(ref TRange left, ref TRange right, ref TRange result, TRanges ranges)
            where T : IComparable<T>
            where TRange : IRange<T>
            where TRanges : IRanges<T, TRange>
        {
            if (!IntersectsWith<T, TRange>(ref left, ref right))
            {
                return false;
            }
            var startToRightStart = left.Start.CompareTo(right.Start);
            var endToRightEnd = left.End.CompareTo(right.End);
            result = 
                ranges.Range(
                    startToRightStart > 0 ? left.Start : right.Start,
                    startToRightStart == 0
                        ? left.OpenStart || right.OpenStart
                        : startToRightStart > 0
                            ? left.OpenStart
                            : right.OpenStart,
                    endToRightEnd < 0 ? left.End : right.End,
                    endToRightEnd == 0
                        ? left.OpenEnd || right.OpenEnd
                        : endToRightEnd < 0
                            ? left.OpenEnd
                            : right.OpenEnd);
            return true;
        }

        public static bool IntersectsWith<T, TRange>(ref TRange left, ref TRange right)
            where T : IComparable<T>
            where TRange : IRange<T>
        {
            if (left.Empty || right.Empty) return false;
            var startToRightEnd = left.Start.CompareTo(right.End);
            if (startToRightEnd > 0) return false;
            var endToRightStart = left.End.CompareTo(right.Start);
            if (endToRightStart < 0) return false;
            if (startToRightEnd == 0) return !left.OpenStart && !right.OpenEnd;
            if (endToRightStart == 0) return !left.OpenEnd && !right.OpenStart;
            return true;
        }
    }
}
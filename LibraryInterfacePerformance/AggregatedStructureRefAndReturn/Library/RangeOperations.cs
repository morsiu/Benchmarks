﻿using System;

namespace LibraryInterfacePerformance.AggregatedStructureRefAndReturn.Library
{
    public static class RangeOperations
    {
        public static Range<T> Intersect<T>(
            ref Range<T> left,
            ref Range<T> right)
            where T : IComparable<T>
        {
            if (!IntersectsWith(ref left, ref right))
            {
                return new Range<T>();
            }
            var leftStartToRightStart = left.Start.CompareTo(right.Start);
            var leftEndToRightEnd = left.End.CompareTo(right.End);
            return
                new Range<T>(
                    leftStartToRightStart > 0 ? left.Start : right.Start,
                    leftStartToRightStart == 0
                        ? left.OpenStart || right.OpenStart
                        : leftStartToRightStart > 0
                            ? left.OpenStart
                            : right.OpenStart,
                    leftEndToRightEnd < 0 ? left.End : right.End,
                    leftEndToRightEnd == 0
                        ? left.OpenEnd || right.OpenEnd
                        : leftEndToRightEnd < 0
                            ? left.OpenEnd
                            : right.OpenEnd);
        }
        
        public static bool IntersectsWith<T>(
            ref Range<T> left,
            ref Range<T> right)
            where T : IComparable<T>
        {
            if (left.Start.CompareTo(right.End) > 0) return false;
            if (left.End.CompareTo(right.Start) < 0) return false;
            if (left.Start.CompareTo(right.End) == 0) return !left.OpenStart && !right.OpenEnd;
            if (left.End.CompareTo(right.Start) == 0) return !left.OpenEnd && !right.OpenStart;
            return true;
        }
    }
}
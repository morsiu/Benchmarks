﻿using System.Collections.Generic;

namespace DotNetPerf.Benchmarks.LogicPackaging.Library
{
    public static class StaticMethodsWithInputAndOutputInStructures
    {
        public static Structure<T>? Intersect<T>(
            Structure<T> left,
            Structure<T> right,
            IComparer<T> comparer)
        {
            if (!IntersectsWith(left, right, comparer))
            {
                return null;
            }
            var leftStartToRightStart = comparer.Compare(left.Start, right.Start);
            var leftEndToRightEnd = comparer.Compare(left.End, right.End);
            return
                new Structure<T>(
                    leftStartToRightStart > 0 ? left.Start : right.Start,
                    leftStartToRightStart == 0
                        ? left.HasOpenStart || right.HasOpenStart
                        : leftStartToRightStart > 0
                            ? left.HasOpenStart
                            : right.HasOpenStart,
                    leftEndToRightEnd < 0 ? left.End : right.End,
                    leftEndToRightEnd == 0
                        ? left.HasOpenEnd || right.HasOpenEnd
                        : leftEndToRightEnd < 0
                            ? left.HasOpenEnd
                            : right.HasOpenEnd);
        }
        
        public static bool IntersectsWith<T>(
            Structure<T> left,
            Structure<T> right,
            IComparer<T> comparer)
        {
            if (comparer.Compare(left.Start, right.End) > 0) return false;
            if (comparer.Compare(left.End, right.Start) < 0) return false;
            if (comparer.Compare(left.Start, right.End) == 0) return !left.HasOpenStart && !right.HasOpenEnd;
            if (comparer.Compare(left.End, right.Start) == 0) return !left.HasOpenEnd && !right.HasOpenStart;
            return true;
        }
    }
}
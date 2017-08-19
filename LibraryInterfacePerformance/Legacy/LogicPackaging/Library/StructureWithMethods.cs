using System;

namespace LibraryInterfacePerformance.Legacy.LogicPackaging.Library
{
    public struct StructureWithMethods<T>
        where T : IComparable<T>
    {
        public T Start { get; }
        public bool HasOpenStart { get; }
        public T End { get; }
        public bool HasOpenEnd { get; }

        public StructureWithMethods(T start, bool hasOpenStart, T end, bool hasOpenEnd)
        {
            Start = start;
            HasOpenStart = hasOpenStart;
            End = end;
            HasOpenEnd = hasOpenEnd;
        }
        
        public StructureWithMethods<T>? Intersect(
            StructureWithMethods<T> right)
        {
            if (!IntersectsWith(right))
            {
                return null;
            }
            var leftStartToRightStart = Start.CompareTo(right.Start);
            var leftEndToRightEnd = End.CompareTo(right.End);
            return
                new StructureWithMethods<T>(
                    leftStartToRightStart > 0 ? Start : right.Start,
                    leftStartToRightStart == 0
                        ? HasOpenStart || right.HasOpenStart
                        : leftStartToRightStart > 0
                            ? HasOpenStart
                            : right.HasOpenStart,
                    leftEndToRightEnd < 0 ? End : right.End,
                    leftEndToRightEnd == 0
                        ? HasOpenEnd || right.HasOpenEnd
                        : leftEndToRightEnd < 0
                            ? HasOpenEnd
                            : right.HasOpenEnd);
        }
        
        public bool IntersectsWith(
            StructureWithMethods<T> right)
        {
            if (Start.CompareTo(right.End) > 0) return false;
            if (End.CompareTo(right.Start) < 0) return false;
            if (Start.CompareTo(right.End) == 0) return !HasOpenStart && !right.HasOpenEnd;
            if (End.CompareTo(right.Start) == 0) return !HasOpenEnd && !right.HasOpenStart;
            return true;
        }
    }
}
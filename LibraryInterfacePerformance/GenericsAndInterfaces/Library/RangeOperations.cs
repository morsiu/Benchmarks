using System;

namespace LibraryInterfacePerformance.GenericsAndInterfaces.Library
{
    public static class RangeOperations
    {
        public static TRange Intersect<T, TRange, TRanges>(TRange left, TRange right)
            where T : IComparable<T>
            where TRange : IRange<T>
            where TRanges : struct, IRanges<T, TRange>
        {
            if (!IntersectsWith<T, TRange>(left, right))
            {
                return default(TRanges).EmptyRange();
            }
            var startToRightStart = left.Start.CompareTo(right.Start);
            var endToRightEnd = left.End.CompareTo(right.End);
            return 
                default(TRanges).Range(
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
        }

        public static bool IntersectsWith<T, TRange>(TRange left, TRange right)
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
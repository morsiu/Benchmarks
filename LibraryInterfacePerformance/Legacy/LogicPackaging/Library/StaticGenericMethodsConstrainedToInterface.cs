using System;

namespace LibraryInterfacePerformance.Legacy.LogicPackaging.Library
{
    public static class StaticGenericMethodsConstrainedToInterface
    {
        public static TData Intersect<T, TData, TDataFactory>(
            ref TData left,
            ref TData right)
            where T : IComparable<T>
            where TData : struct, IData<T, TData, TDataFactory>
            where TDataFactory : struct, IDataFactory<T, TData, TDataFactory>
        {
            if (!IntersectsWith<T, TData, TDataFactory>(ref left, ref right))
            {
                return default(TDataFactory).EmptyData();
            }
            var leftStartToRightStart = left.Start.CompareTo(right.Start);
            var leftEndToRightEnd = left.End.CompareTo(right.End);
            return
                default(TDataFactory).Data(
                    leftStartToRightStart > 0 ? left.Start : right.Start,
                    leftEndToRightEnd < 0 ? left.End : right.End,
                    leftEndToRightEnd == 0
                        ? left.HasOpenEnd || right.HasOpenEnd
                        : leftEndToRightEnd < 0
                            ? left.HasOpenEnd
                            : right.HasOpenEnd,
                    leftStartToRightStart == 0
                        ? left.HasOpenStart || right.HasOpenStart
                        : leftStartToRightStart > 0
                            ? left.HasOpenStart
                            : right.HasOpenStart);
        }
        
        public static bool IntersectsWith<T, TData, TDataFactory>(
            ref TData left,
            ref TData right)
            where T : IComparable<T>
            where TData : struct, IData<T, TData, TDataFactory>
            where TDataFactory : struct, IDataFactory<T, TData, TDataFactory>
        {
            if (left.IsEmpty || right.IsEmpty) return false;
            if (left.Start.CompareTo(right.End) > 0) return false;
            if (left.End.CompareTo(right.Start) < 0) return false;
            if (left.Start.CompareTo(right.End) == 0) return !left.HasOpenStart && !right.HasOpenEnd;
            if (left.End.CompareTo(right.Start) == 0) return !left.HasOpenEnd && !right.HasOpenStart;
            return true;
        }
    }
}
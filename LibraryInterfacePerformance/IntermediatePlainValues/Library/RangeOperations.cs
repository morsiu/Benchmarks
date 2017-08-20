using System;

namespace LibraryInterfacePerformance.IntermediatePlainValues.Library
{
    public static class RangeOperations
    {
        public static bool Intersect<T>(
            T leftStart, bool leftHasOpenStart, T leftEnd, bool leftHasOpenEnd,
            T rightStart, bool rightHasOpenStart, T rightEnd, bool rightHasOpenEnd,
            out T resultStart, out bool resultHasOpenStart, out T resultEnd, out bool resultHasOpenEnd)
            where T : IComparable<T>
        {
            if (!IntersectsWith(
                    leftStart, leftHasOpenStart, leftEnd, leftHasOpenEnd,
                    rightStart, rightHasOpenStart, rightEnd, rightHasOpenEnd))
            {
                resultStart = default(T);
                resultHasOpenStart = default(bool);
                resultEnd = default(T);
                resultHasOpenEnd = default(bool);
                return false;
            }
            var leftStartToRightStart = leftStart.CompareTo(rightStart);
            var leftEndToRightEnd = leftEnd.CompareTo(rightEnd);
            resultStart = leftStartToRightStart > 0 ? leftStart : rightStart;
            resultEnd = leftEndToRightEnd < 0 ? leftEnd : rightEnd;
            resultHasOpenStart =
                leftStartToRightStart == 0
                    ? leftHasOpenStart || rightHasOpenStart
                    : leftStartToRightStart > 0
                        ? leftHasOpenStart
                        : rightHasOpenStart;
            resultHasOpenEnd =
                leftEndToRightEnd == 0
                    ? leftHasOpenEnd || rightHasOpenEnd
                    : leftEndToRightEnd < 0
                        ? leftHasOpenEnd
                        : rightHasOpenEnd;
            return true;
        }
        
        public static bool IntersectsWith<T>(
            T leftStart, bool leftHasOpenStart, T leftEnd, bool leftHasOpenEnd,
            T rightStart, bool rightHasOpenStart, T rightEnd, bool rightHasOpenEnd)
            where T : IComparable<T>
        {
            if (leftStart.CompareTo(rightEnd) > 0) return false;
            if (leftEnd.CompareTo(rightStart) < 0) return false;
            if (leftStart.CompareTo(rightEnd) == 0) return !leftHasOpenStart && !rightHasOpenEnd;
            if (leftEnd.CompareTo(rightStart) == 0) return !leftHasOpenEnd && !rightHasOpenStart;
            return true;
        }
    }
}
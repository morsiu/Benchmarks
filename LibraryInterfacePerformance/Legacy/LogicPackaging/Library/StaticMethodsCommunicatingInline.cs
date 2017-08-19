using System.Collections.Generic;

namespace LibraryInterfacePerformance.Legacy.LogicPackaging.Library
{
    public static class StaticMethodsCommunicatingInline
    {
        public static bool Intersect<T>(
            T leftStart, bool leftHasOpenStart, T leftEnd, bool leftHasOpenEnd,
            T rightStart, bool rightHasOpenStart, T rightEnd, bool rightHasOpenEnd,
            out T resultStart, out bool resultHasOpenStart, out T resultEnd, out bool resultHasOpenEnd,
            IComparer<T> comparer)
        {
            if (!IntersectsWith(leftStart, leftHasOpenStart, leftEnd, leftHasOpenEnd,
                rightStart, rightHasOpenStart, rightEnd, rightHasOpenEnd, comparer))
            {
                resultStart = default(T);
                resultHasOpenStart = default(bool);
                resultEnd = default(T);
                resultHasOpenEnd = default(bool);
                return false;
            }
            var leftStartToRightStart = comparer.Compare(leftStart, rightStart);
            var leftEndToRightEnd = comparer.Compare(leftEnd, rightEnd);
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
            T rightStart, bool rightHasOpenStart, T rightEnd, bool rightHasOpenEnd,
            IComparer<T> comparer)
        {
            if (comparer.Compare(leftStart, rightEnd) > 0) return false;
            if (comparer.Compare(leftEnd, rightStart) < 0) return false;
            if (comparer.Compare(leftStart, rightEnd) == 0) return !leftHasOpenStart && !rightHasOpenEnd;
            if (comparer.Compare(leftEnd, rightStart) == 0) return !leftHasOpenEnd && !rightHasOpenStart;
            return true;
        }
    }
}
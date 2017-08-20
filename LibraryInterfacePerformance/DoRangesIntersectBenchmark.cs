using System;

namespace LibraryInterfacePerformance
{
    public struct DoRangesIntersectBenchmark<T, TRange>
        where T : IComparable<T>
        where TRange : IRange<T, TRange>
    {
        private readonly TRange[] _firstList;
        private readonly TRange[] _secondList;

        public DoRangesIntersectBenchmark(TRange[] firstList, TRange[] secondList)
        {
            if (firstList.Length != secondList.Length)
                throw new ArgumentException("Arrays have different length");
            _firstList = firstList;
            _secondList = secondList;
        }

        public bool Run()
        {
            var result = false;
            for (var index = 0; index < Count; ++index)
            {
                result |= _firstList[index].IntersectsWith(_secondList[index]);
            }
            return result;            
        }
        
        private int Count => _firstList.Length;
    }
}
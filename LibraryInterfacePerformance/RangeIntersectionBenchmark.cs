using System;

namespace LibraryInterfacePerformance
{
    public struct RangeIntersectionBenchmark<T, TRange>
        where T : IComparable<T>
        where TRange : IRange<T, TRange>
    {
        private readonly TRange[] _firstList;
        private readonly TRange[] _secondList;
        private readonly TRange[] _resultList;

        public RangeIntersectionBenchmark(TRange[] firstList, TRange[] secondList, TRange[] resultList)
        {
            if (firstList.Length != secondList.Length || firstList.Length != resultList.Length)
                throw new ArgumentException("Arrays have different lengths");
            _firstList = firstList;
            _secondList = secondList;
            _resultList = resultList;
        }

        public void Run()
        {
            for (var index = 0; index < Count; ++index)
            {
                _resultList[index] = _firstList[index].Intersect(_secondList[index]);
            }           
        }

        private int Count => _firstList.Length;
    }
}
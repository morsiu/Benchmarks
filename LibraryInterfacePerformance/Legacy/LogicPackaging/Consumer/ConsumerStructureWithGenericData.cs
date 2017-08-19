using System;
using LibraryInterfacePerformance.Legacy.LogicPackaging.Library;

namespace LibraryInterfacePerformance.Legacy.LogicPackaging.Consumer
{
    public struct ConsumerStructureWithGenericData<T>
        where T : IComparable<T>
    {
        private Data<T> _data;

        public ConsumerStructureWithGenericData(T start, bool hasOpenStart, T end, bool hasOpenEnd)
        {
            _data = new Data<T>(start, end, hasOpenStart, hasOpenEnd);
        }

        private ConsumerStructureWithGenericData(Data<T> data)
        {
            _data = data;
        }
        
        public ConsumerStructureWithGenericData<T> IntersectUsingStaticGenericMethodWithClasses(ConsumerStructureWithGenericData<T> other)
        {
            return new ConsumerStructureWithGenericData<T>(
                StaticGenericMethodsConstrainedToInterface.Intersect<T, Data<T>, DataFactory<T>>(
                    ref _data,
                    ref other._data));
        }
    }

    public struct DataFactory<T> : IDataFactory<T, Data<T>, DataFactory<T>>
        where T : IComparable<T>
    {
        public Data<T> Data(T start, T end, bool hasOpenStart, bool hasOpenEnd)
        {
            return new Data<T>(start, end, hasOpenStart, hasOpenEnd);
        }

        public Data<T> EmptyData()
        {
            return new Data<T>();
        }
    }

    public struct Data<T> : IData<T, Data<T>, DataFactory<T>>
        where T : IComparable<T>
    {
        private readonly bool _isNotEmpty;

        public Data(T start, T end, bool hasOpenStart, bool hasOpenEnd)
        {
            Start = start;
            End = end;
            HasOpenEnd = hasOpenEnd;
            HasOpenStart = hasOpenStart;
            _isNotEmpty = true;
        }
        
        public bool HasOpenStart { get; }
        public T Start { get; }
        public bool HasOpenEnd { get; }
        public T End { get; }
        public bool IsEmpty => !_isNotEmpty;
    }
}
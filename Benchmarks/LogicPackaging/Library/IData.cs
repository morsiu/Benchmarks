using System;

namespace DotNetPerf.Benchmarks.LogicPackaging.Library
{
    public interface IData<out T, TData, TDataFactory>
        where T : IComparable<T>
        where TData : struct, IData<T, TData, TDataFactory>
        where TDataFactory : struct, IDataFactory<T, TData, TDataFactory>
    {
        bool HasOpenStart { get; }
        T Start { get; }
        bool HasOpenEnd { get; }
        T End { get; }
        bool IsEmpty { get; }
    }

    public interface IDataFactory<in T, out TData, TDataFactory>
        where T : IComparable<T>
        where TData : struct, IData<T, TData, TDataFactory>
        where TDataFactory : struct, IDataFactory<T, TData, TDataFactory>
    {
        TData Data(T start, T end, bool hasOpenStart, bool hasOpenEnd);
        TData EmptyData();
    }
}
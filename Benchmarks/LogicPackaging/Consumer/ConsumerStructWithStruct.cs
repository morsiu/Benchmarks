using System.Collections.Generic;
using DotNetPerf.Benchmarks.LogicPackaging.Library;

namespace DotNetPerf.Benchmarks.LogicPackaging.Consumer
{
    public struct ConsumerStructWithStruct<T>
    {
        private readonly Structure<T>? _structure;

        public ConsumerStructWithStruct(T start, bool hasOpenStart, T end, bool hasOpenEnd)
        {
            _structure = new Structure<T>(start, hasOpenStart, end, hasOpenEnd);
        }

        private ConsumerStructWithStruct(Structure<T>? structure)
        {
            _structure = structure;
        }
        
        public ConsumerStructWithStruct<T> IntersectUsingStaticMethodWithStructures(ConsumerStructWithStruct<T> other)
        {
            if (_structure == null || other._structure == null) return new ConsumerStructWithStruct<T>();
            return new ConsumerStructWithStruct<T>(
                StaticMethodsWithInputAndOutputInStructures.Intersect(
                    _structure.Value,
                    other._structure.Value,
                    Comparer<T>.Default));
        }
    }
}
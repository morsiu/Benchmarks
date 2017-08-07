using System.Collections.Generic;
using DotNetPerf.Benchmarks.LogicPackaging.Library;

namespace DotNetPerf.Benchmarks.LogicPackaging.Consumer
{
    public struct ConsumerStructuctureWithStructure<T>
    {
        private Structure<T>? _structure;

        public ConsumerStructuctureWithStructure(T start, bool hasOpenStart, T end, bool hasOpenEnd)
        {
            _structure = new Structure<T>(start, hasOpenStart, end, hasOpenEnd);
        }

        private ConsumerStructuctureWithStructure(Structure<T>? structure)
        {
            _structure = structure;
        }
        
        public ConsumerStructuctureWithStructure<T> IntersectUsingStaticMethodWithStructures(ConsumerStructuctureWithStructure<T> other)
        {
            if (_structure == null || other._structure == null) return new ConsumerStructuctureWithStructure<T>();
            return new ConsumerStructuctureWithStructure<T>(
                StaticMethodsCommunicatingWithStructures.Intersect(
                    _structure.Value,
                    other._structure.Value,
                    Comparer<T>.Default));
        }
    }
}
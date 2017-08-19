using System.Collections.Generic;
using DotNetPerf.Benchmarks.LogicPackaging.Library;

namespace DotNetPerf.Benchmarks.LogicPackaging.Consumer
{
    public struct ConsumerStructureWithStructure<T>
    {
        private Structure<T>? _structure;

        public ConsumerStructureWithStructure(T start, bool hasOpenStart, T end, bool hasOpenEnd)
        {
            _structure = new Structure<T>(start, hasOpenStart, end, hasOpenEnd);
        }

        private ConsumerStructureWithStructure(Structure<T>? structure)
        {
            _structure = structure;
        }
        
        public ConsumerStructureWithStructure<T> IntersectUsingStaticMethodWithStructures(ConsumerStructureWithStructure<T> other)
        {
            if (_structure == null || other._structure == null) return new ConsumerStructureWithStructure<T>();
            return new ConsumerStructureWithStructure<T>(
                StaticMethodsCommunicatingWithStructures.Intersect(
                    _structure.Value,
                    other._structure.Value,
                    Comparer<T>.Default));
        }
    }
}
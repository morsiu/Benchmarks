using System.Collections.Generic;
using DotNetPerf.Benchmarks.LogicPackaging.Library;

namespace DotNetPerf.Benchmarks.LogicPackaging.Consumer
{
    public struct ConsumerStructureWithClass<T>
    {
        private readonly Class<T> _class;

        public ConsumerStructureWithClass(T start, bool hasOpenStart, T end, bool hasOpenEnd)
        {
            _class = new Class<T>(start, hasOpenStart, end, hasOpenEnd);
        }

        private ConsumerStructureWithClass(Class<T> @class)
        {
            _class = @class;
        }
        
        public ConsumerStructureWithClass<T> IntersectUsingStaticMethodWithStructures(ConsumerStructureWithClass<T> other)
        {
            if (_class == null || other._class == null) return new ConsumerStructureWithClass<T>();
            return new ConsumerStructureWithClass<T>(
                StaticMethodsCommunicatingWithClasses.Intersect(
                    _class,
                    other._class,
                    Comparer<T>.Default));
        }
    }
}
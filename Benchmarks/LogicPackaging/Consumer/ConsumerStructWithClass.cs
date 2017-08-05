using System.Collections.Generic;
using DotNetPerf.Benchmarks.LogicPackaging.Library;

namespace DotNetPerf.Benchmarks.LogicPackaging.Consumer
{
    public struct ConsumerStructWithClass<T>
    {
        private readonly Class<T> _class;

        public ConsumerStructWithClass(T start, bool hasOpenStart, T end, bool hasOpenEnd)
        {
            _class = new Class<T>(start, hasOpenStart, end, hasOpenEnd);
        }

        private ConsumerStructWithClass(Class<T> @class)
        {
            _class = @class;
        }
        
        public ConsumerStructWithClass<T> IntersectUsingStaticMethodWithStructures(ConsumerStructWithClass<T> other)
        {
            if (_class == null || other._class == null) return new ConsumerStructWithClass<T>();
            return new ConsumerStructWithClass<T>(
                StaticMethodsWithInputAndOutputInClasses.Intersect(
                    _class,
                    other._class,
                    Comparer<T>.Default));
        }
    }
}
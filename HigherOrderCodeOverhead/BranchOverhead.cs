using System;
using BenchmarkDotNet.Attributes;

namespace HigherOrderCodeOverhead
{
    [Config(typeof(OverheadConfig))]
    public class BranchOverhead
    {
        public struct StructOption<T>
        {
            private readonly T _value;
            private readonly bool _hasValue;

            public StructOption(T value)
            {
                _value = value;
                _hasValue = true;
            }

            public T Value => _value;

            public bool HasValue => _hasValue;

            public StructOption<TU> Map<TU>(Func<T, TU> map)
            {
                return HasValue
                    ? new StructOption<TU>(map(_value))
                    : new StructOption<TU>();
            }
        }

        [Benchmark]
        public StructOption<int> MapByHand()
        {
            var input = new StructOption<int>(5);
            return input.HasValue
                ? new StructOption<int>(10)
                : new StructOption<int>();
        }

        [Benchmark]
        public StructOption<int> MapWithDelegate()
        {
            var input = new StructOption<int>(5);
            return input.Map(x => x * 2);
        }
    }
}
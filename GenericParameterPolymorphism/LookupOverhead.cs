using System;
using BenchmarkDotNet.Attributes;

namespace GenericParameterPolymorphism
{
    [Config(typeof(OverheadConfig))]
    public class LookupOverhead
    {
        [GlobalSetup]
        public void GlobalSetup()
        {
            Value<int>(new object());
            Value<long>(new object());
            Value<DateTime>(new object());
            Value<Version>(new object());
            Value<TimeSpan>(new object());
            Value<decimal>(new object());
            Value<string>(new object());
            Value<double>(new object());
            Value<Type>(new object());
            Value<object>(new object());

            void Value<T>(object value)
            {
                DictionaryLookup.Current<T>(value);
                GenericLookup<T>.Current(value);
            }
        }

        [Benchmark]
        public object SingleLookupInDictionaryLookup()
        {
            return DictionaryLookup.Current<DateTime>();
        }

        [Benchmark]
        public object SingleLookupInGenericLookup()
        {
            return GenericLookup<DateTime>.Current();
        }
    }
}

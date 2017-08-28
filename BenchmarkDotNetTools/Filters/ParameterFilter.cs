using System;
using System.Linq;
using BenchmarkDotNet.Filters;
using BenchmarkDotNet.Running;

namespace BenchmarkDotNetTools.Filters
{
    public sealed class ParameterFilter : IFilter
    {
        private readonly string _nameOfParameter;
        private readonly Predicate<object> _predicateOnParameterValue;

        public ParameterFilter(string nameOfParameter, Predicate<object> predicateOnParameterValue)
        {
            _nameOfParameter = nameOfParameter;
            _predicateOnParameterValue = predicateOnParameterValue;
        }
        
        public bool Predicate(Benchmark benchmark)
        {
            return benchmark.Parameters.Items.Any(x => Equals(x.Name, _nameOfParameter) && _predicateOnParameterValue(x.Value));
       }
    }
}
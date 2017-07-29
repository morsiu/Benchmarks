using BenchmarkDotNet.Running;
using DotNetPerf.Benchmarks;

namespace DotNetPerf
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<Equals_on_value_types>();
        }
    }
}

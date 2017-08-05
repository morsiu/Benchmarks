using BenchmarkDotNet.Running;
//using DotNetPerf.Benchmarks;
using DotNetPerf.Benchmarks.LogicPackaging;

namespace DotNetPerf
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            //BenchmarkRunner.Run<Logic_packaging__for_many_structure_parameters>();
            //BenchmarkRunner.Run<Logic_packaging__for_one_parameter>();
            BenchmarkRunner.Run<LogicPackagingBenchmark>();
        }
    }
}

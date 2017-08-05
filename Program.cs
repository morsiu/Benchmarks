using BenchmarkDotNet.Running;
using DotNetPerf.Benchmarks;

namespace DotNetPerf
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            //BenchmarkRunner.Run<Logic_packaging__for_many_structure_parameters>();
            BenchmarkRunner.Run<Logic_packaging__for_one_parameter>();
        }
    }
}

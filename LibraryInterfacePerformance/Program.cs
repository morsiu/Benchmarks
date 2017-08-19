using BenchmarkDotNet.Running;
using LibraryInterfacePerformance.Legacy;
using LibraryInterfacePerformance.Legacy.LogicPackaging;

namespace LibraryInterfacePerformance
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<Logic_packaging__for_many_structure_parameters>();
            BenchmarkRunner.Run<Logic_packaging__for_one_parameter>();
            BenchmarkRunner.Run<LogicPackagingBenchmark>();
            BenchmarkRunner.Run<DataPassingBenchmark>();
        }
    }
}

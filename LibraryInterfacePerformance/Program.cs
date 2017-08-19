using BenchmarkDotNet.Running;
using LibraryInterfacePerformance.Legacy;
using LibraryInterfacePerformance.Legacy.LogicPackaging;

namespace LibraryInterfacePerformance
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<TransientClassesBenchmark>();
        }
    }
}

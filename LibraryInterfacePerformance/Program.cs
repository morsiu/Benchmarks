using BenchmarkDotNet.Running;

namespace LibraryInterfacePerformance
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<ApproachesBenchmarks>();
        }
    }
}

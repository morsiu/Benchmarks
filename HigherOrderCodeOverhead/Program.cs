using BenchmarkDotNet.Running;

namespace HigherOrderCodeOverhead
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<BranchOverhead>();
        }
    }
}

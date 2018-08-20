using BenchmarkDotNet.Running;

namespace QueryableOverhead
{
    public class Program
    {
        private static void Main(string[] args)
        {
            BenchmarkRunner.Run<EnumerableAsQueryableOverhead>();
        }
    }
}
using BenchmarkDotNet.Running;

namespace GenericParameterPolymorphism
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<LookupOverhead>();
        }
    }
}

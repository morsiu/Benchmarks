using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Jobs;

namespace LibraryInterfacePerformance
{
    public sealed class BenchmarkConfig : ManualConfig
    {
        public BenchmarkConfig()
        {
            Add(MemoryDiagnoser.Default);
            Add(Job.RyuJitX64);
            //Add(Job.LegacyJitX64);
            //Add(Job.LegacyJitX86);
        }
    }
}
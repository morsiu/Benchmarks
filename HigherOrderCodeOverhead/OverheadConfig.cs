using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Jobs;

namespace HigherOrderCodeOverhead
{
    public class OverheadConfig : ManualConfig
    {
        public OverheadConfig()
        {
            Add(new MemoryDiagnoser());
            Add(Job.LegacyJitX86);
            Add(Job.LegacyJitX64);
            Add(Job.RyuJitX64);
        }
    }
}
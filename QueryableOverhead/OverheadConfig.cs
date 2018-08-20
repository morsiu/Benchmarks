using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;

namespace QueryableOverhead
{
    public class OverheadConfig : ManualConfig
    {
        public OverheadConfig()
        {
            Add(new MemoryDiagnoser());
        }
    }
}
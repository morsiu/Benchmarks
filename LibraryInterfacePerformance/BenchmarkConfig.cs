using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Jobs;

namespace LibraryInterfacePerformance
{
    public sealed class BenchmarkConfig : ManualConfig
    {
        public BenchmarkConfig()
        {
            Add(MemoryDiagnoser.Default);
            Add(Job.RyuJitX64);
            Add(Job.LegacyJitX64);
            Add(Job.LegacyJitX86);
            Add(RPlotExporter.Default);
            Add(CsvMeasurementsExporter.Default);
        }
    }
}
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Jobs;

namespace LibraryInterfacePerformance.LogicPackaging
{
    public class BaseConfig : ManualConfig
    {
        public BaseConfig()
        {
            Add(new MemoryDiagnoser());
            //Add(RPlotExporter.Default);
            Add(CsvMeasurementsExporter.Default);
            Add(Job.LegacyJitX86);
            Add(Job.LegacyJitX64);
            Add(Job.RyuJitX64);
        }
    }
}
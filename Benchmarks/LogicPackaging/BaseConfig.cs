using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Jobs;
using DotNetPerf.Infrastructure.Columns;

namespace DotNetPerf.Benchmarks.LogicPackaging
{
    public class BaseConfig : ManualConfig
    {
        public BaseConfig()
        {
            Add(new MemoryDiagnoser());
            //Add(RPlotExporter.Default);
            //Add(CsvMeasurementsExporter.Default);
            Add(Job.LegacyJitX86);
            Add(Job.LegacyJitX64);
            Add(Job.RyuJitX64);
        }
    }
}
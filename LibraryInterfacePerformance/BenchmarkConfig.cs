using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Horology;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Reports;

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
            Add(new CsvMeasurementsExporter(CsvSeparator.CurrentCulture,
                new SummaryStyle
                {
                    PrintUnitsInContent = false,
                    PrintUnitsInHeader = true,
                    TimeUnit = TimeUnit.Nanosecond,
                    SizeUnit = SizeUnit.B
                }));
        }
    }
}
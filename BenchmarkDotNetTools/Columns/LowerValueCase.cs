using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace BenchmarkDotNetTools.Columns
{
    public sealed class LowerValueCase : IColumn
    {
        private readonly IColumn _column;

        public LowerValueCase(IColumn column)
        {
            _column = column;
        }

        public string Id => _column.Id;
        public string ColumnName => _column.ColumnName;
        public bool AlwaysShow => _column.AlwaysShow;
        public ColumnCategory Category => _column.Category;
        public int PriorityInCategory => _column.PriorityInCategory;
        public bool IsNumeric => _column.IsNumeric;
        public UnitType UnitType => _column.UnitType;
        public string Legend => _column.Legend;

        public string GetValue(Summary summary, Benchmark benchmark) =>
            _column.GetValue(summary, benchmark).ToLowerInvariant();

        public string GetValue(Summary summary, Benchmark benchmark, ISummaryStyle style) =>
            _column.GetValue(summary, benchmark, style);
        
        public bool IsAvailable(Summary summary) => _column.IsAvailable(summary);
        public bool IsDefault(Summary summary, Benchmark benchmark) => _column.IsDefault(summary, benchmark);
    }
}

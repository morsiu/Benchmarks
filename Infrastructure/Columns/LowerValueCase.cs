using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace DotNetPerf.Infrastructure.Columns
{
    internal sealed class LowerValueCase : IColumn
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
        public string GetValue(Summary summary, Benchmark benchmark) => _column.GetValue(summary, benchmark).ToLowerInvariant();
        public bool IsAvailable(Summary summary) => _column.IsAvailable(summary);
        public bool IsDefault(Summary summary, Benchmark benchmark) => _column.IsDefault(summary, benchmark);
    }
}

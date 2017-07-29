using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace DotNetPerf.Infrastructure.Columns
{
    internal sealed class ChangeId : IColumn
    {
        private readonly IColumn _column;
        private readonly string _id;

        public ChangeId(string id, IColumn column)
        {
            _id = id;
            _column = column;
        }

        public string Id => _id;
        public string ColumnName => _column.ColumnName;
        public bool AlwaysShow => _column.AlwaysShow;
        public ColumnCategory Category => _column.Category;
        public int PriorityInCategory => _column.PriorityInCategory;
        public string GetValue(Summary summary, Benchmark benchmark) => _column.GetValue(summary, benchmark);
        public bool IsAvailable(Summary summary) => _column.IsAvailable(summary);
        public bool IsDefault(Summary summary, Benchmark benchmark) => _column.IsDefault(summary, benchmark);
    }
}

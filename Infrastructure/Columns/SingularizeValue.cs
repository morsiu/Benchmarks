using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace DotNetPerf.Infrastructure.Columns
{
    internal sealed class SingularizeValue : IColumn
    {
        private readonly IColumn _column;

        public SingularizeValue(IColumn column)
        {
            _column = column;
        }

        public string GetValue(Summary summary, Benchmark benchmark)
        {
            var value = _column.GetValue(summary, benchmark);
            var firstSeparatorIndex = value.IndexOf("_");
            if (firstSeparatorIndex <= 0)
            {
                return value;
            }
            var pluralPart = value.Substring(0, firstSeparatorIndex);
            var singularizedPluralPart = pluralPart.Substring(0, pluralPart.Length - 1);
            return singularizedPluralPart + value.Substring(pluralPart.Length);
        }

        public string Id => _column.Id;
        public string ColumnName => _column.ColumnName;
        public bool AlwaysShow => _column.AlwaysShow;
        public ColumnCategory Category => _column.Category;
        public int PriorityInCategory => _column.PriorityInCategory;
        public bool IsAvailable(Summary summary) => _column.IsAvailable(summary);
        public bool IsDefault(Summary summary, Benchmark benchmark) => _column.IsDefault(summary, benchmark);
    }
}

using System;

namespace BenchmarkDotNetTools.Columns
{
    public sealed class ColumnName
    {
        private string _name;

        public ColumnName(string name)
        {
            _name = name;
        }

        public ColumnName NthToken(int index, string[] separators)
        {
            return new ColumnName(_name.Split(separators, StringSplitOptions.RemoveEmptyEntries)[index]);
        }

        public static implicit operator string(ColumnName columnName)
        {
            return columnName._name;
        }
    }
}

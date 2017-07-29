using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using DotNetPerf.Infrastructure.Columns;
using System;
using System.Collections.Generic;

namespace DotNetPerf.Benchmarks
{
    [Config(typeof(Config))]
    public class Equals_on_value_types
    {
        private struct Struct_of_value_fields_with_default_equals
        {
            private int Value_field { get; set; }
        }

        private struct Struct_of_reference_fields_with_default_equals
        {
            private string Reference_field { get; set; }
        }

        private struct Struct_of_mixed_fields_with_default_equals
        {
            private string Reference_field { get; set; }
            private int Value_field { get; set; }
        }

        private struct Struct_of_mixed_fields_with_overriden_equals
        {
            private string Reference_field { get; set; }
            private int Value_field { get; set; }

            public override bool Equals(object obj)
            {
                return obj is Struct_of_mixed_fields_with_overriden_equals
                    && Typed_equals((Struct_of_mixed_fields_with_overriden_equals)obj);
            }

            public bool Typed_equals(Struct_of_mixed_fields_with_overriden_equals other)
            {
                return Equals(Reference_field, other.Reference_field)
                    && Value_field.Equals(other.Value_field);
            }
        }

        private struct Struct_of_reference_fields_with_overriden_equals
        {
            private string Reference_field { get; set; }

            public override bool Equals(object obj)
            {
                return obj is Struct_of_reference_fields_with_overriden_equals
                    && Typed_equals((Struct_of_reference_fields_with_overriden_equals)obj);
            }

            public bool Typed_equals(Struct_of_reference_fields_with_overriden_equals other)
            {
                return Equals(Reference_field, other.Reference_field);
            }
        }

        private struct Struct_of_value_fields_with_overriden_equals
        {
            private int Value_field { get; set; }

            public override bool Equals(object obj)
            {
                return obj is Struct_of_value_fields_with_overriden_equals
                    && Typed_equals((Struct_of_value_fields_with_overriden_equals)obj);
            }

            public bool Typed_equals(Struct_of_value_fields_with_overriden_equals other)
            {
                return Value_field.Equals(other.Value_field);
            }
        }

        private struct Struct_of_mixed_fields_with_equatable_interface : IEquatable<Struct_of_mixed_fields_with_equatable_interface>
        {
            private string Reference_field { get; set; }
            private int Value_field { get; set; }

            public override bool Equals(object obj)
            {
                return obj is Struct_of_mixed_fields_with_equatable_interface
                    && Equals((Struct_of_mixed_fields_with_equatable_interface)obj);
            }

            public bool Equals(Struct_of_mixed_fields_with_equatable_interface other)
            {
                return Equals(Reference_field, other.Reference_field)
                    && Value_field.Equals(other.Value_field);
            }
        }

        private struct Struct_of_reference_fields_with_equatable_interface : IEquatable<Struct_of_reference_fields_with_equatable_interface>
        {
            private string Reference_field { get; set; }

            public override bool Equals(object obj)
            {
                return obj is Struct_of_reference_fields_with_equatable_interface
                    && Equals((Struct_of_reference_fields_with_equatable_interface)obj);
            }

            public bool Equals(Struct_of_reference_fields_with_equatable_interface other)
            {
                return Equals(Reference_field, other.Reference_field);
            }
        }

        private struct Struct_of_value_fields_with_equatable_interface : IEquatable<Struct_of_value_fields_with_equatable_interface>
        {
            private int Value_field { get; set; }

            public override bool Equals(object obj)
            {
                return obj is Struct_of_value_fields_with_equatable_interface
                    && Equals((Struct_of_value_fields_with_equatable_interface)obj);
            }

            public bool Equals(Struct_of_value_fields_with_equatable_interface other)
            {
                return Value_field.Equals(other.Value_field);
            }
        }

        [Benchmark]
        public void Instance_equals__on__structs_of_value_fields__with__default_equals()
        {
            new Struct_of_value_fields_with_default_equals().Equals(new Struct_of_value_fields_with_default_equals());
        }

        [Benchmark]
        public void Static_equals__on__structs_of_value_fields__with__default_equals()
        {
            Equals(new Struct_of_value_fields_with_default_equals(), new Struct_of_value_fields_with_default_equals());
        }

        [Benchmark]
        public void Equality_comparer_equals__on__structs_of_value_fields__with__default_equals()
        {
            EqualityComparer<Struct_of_value_fields_with_default_equals>.Default.Equals(
                new Struct_of_value_fields_with_default_equals(),
                new Struct_of_value_fields_with_default_equals());
        }

        [Benchmark]
        public void Instance_equals__on__structs_of_reference_fields__with__default_equals()
        {
            new Struct_of_reference_fields_with_default_equals().Equals(new Struct_of_reference_fields_with_default_equals());
        }

        [Benchmark]
        public void Static_equals__on__structs_of_reference_fields__with__default_equals()
        {
            Equals(new Struct_of_reference_fields_with_default_equals(), new Struct_of_reference_fields_with_default_equals());
        }

        [Benchmark]
        public void Equality_comparer_equals__on__structs_of_reference_fields__with__default_equals()
        {
            EqualityComparer<Struct_of_reference_fields_with_default_equals>.Default.Equals(
                new Struct_of_reference_fields_with_default_equals(),
                new Struct_of_reference_fields_with_default_equals());
        }

        [Benchmark]
        public void Instance_equals__on__structs_of_mixed_fields__with__default_equals()
        {
            new Struct_of_mixed_fields_with_default_equals().Equals(new Struct_of_mixed_fields_with_default_equals());
        }

        [Benchmark]
        public void Static_equals__on__structs_of_mixed_fields__with__default_equals()
        {
            Equals(new Struct_of_mixed_fields_with_default_equals(), new Struct_of_mixed_fields_with_default_equals());
        }

        [Benchmark]
        public void Equality_comparer_equals__on__structs_of_mixed_fields__with__default_equals()
        {
            EqualityComparer<Struct_of_mixed_fields_with_default_equals>.Default.Equals(
                new Struct_of_mixed_fields_with_default_equals(),
                new Struct_of_mixed_fields_with_default_equals());
        }

        [Benchmark]
        public void Instance_equals__on__structs_of_mixed_fields__with__overriden_equals()
        {
            new Struct_of_mixed_fields_with_overriden_equals().Equals(new Struct_of_mixed_fields_with_overriden_equals());
        }

        [Benchmark]
        public void Static_equals__on__structs_of_mixed_fields__with__overriden_equals()
        {
            Equals(new Struct_of_mixed_fields_with_overriden_equals(), new Struct_of_mixed_fields_with_overriden_equals());
        }

        [Benchmark]
        public void Equality_comparer_equals__on__structs_of_mixed_fields__with__overriden_equals()
        {
            EqualityComparer<Struct_of_mixed_fields_with_overriden_equals>.Default.Equals(
                new Struct_of_mixed_fields_with_overriden_equals(),
                new Struct_of_mixed_fields_with_overriden_equals());
        }

        [Benchmark]
        public void Instance_typed_equals__on__structs_of_mixed_fields__with__overriden_equals()
        {
            new Struct_of_mixed_fields_with_overriden_equals().Typed_equals(new Struct_of_mixed_fields_with_overriden_equals());
        }

        [Benchmark]
        public void Instance_equals__on__structs_of_reference_fields__with__overriden_equals()
        {
            new Struct_of_reference_fields_with_overriden_equals().Equals(new Struct_of_reference_fields_with_overriden_equals());
        }

        [Benchmark]
        public void Static_equals__on__structs_of_reference_fields__with__overriden_equals()
        {
            Equals(new Struct_of_reference_fields_with_overriden_equals(), new Struct_of_reference_fields_with_overriden_equals());
        }

        [Benchmark]
        public void Equality_comparer_equals__on__structs_of_reference_fields__with__overriden_equals()
        {
            EqualityComparer<Struct_of_reference_fields_with_overriden_equals>.Default.Equals(
                new Struct_of_reference_fields_with_overriden_equals(),
                new Struct_of_reference_fields_with_overriden_equals());
        }

        [Benchmark]
        public void Instance_typed_equals__on__structs_of_reference_fields__with__overriden_equals()
        {
            new Struct_of_reference_fields_with_overriden_equals().Typed_equals(new Struct_of_reference_fields_with_overriden_equals());
        }

        [Benchmark]
        public void Instance_equals__on__structs_of_value_fields__with__overriden_equals()
        {
            new Struct_of_value_fields_with_overriden_equals().Equals(new Struct_of_value_fields_with_overriden_equals());
        }

        [Benchmark]
        public void Static_equals__on__structs_of_value_fields__with__overriden_equals()
        {
            Equals(new Struct_of_value_fields_with_overriden_equals(), new Struct_of_value_fields_with_overriden_equals());
        }

        [Benchmark]
        public void Equality_comparer_equals__on__structs_of_value_fields__with__overriden_equals()
        {
            EqualityComparer<Struct_of_value_fields_with_overriden_equals>.Default.Equals(
                new Struct_of_value_fields_with_overriden_equals(),
                new Struct_of_value_fields_with_overriden_equals());
        }

        [Benchmark]
        public void Instance_typed_equals__on__structs_of_value_fields__with__overriden_equals()
        {
            new Struct_of_value_fields_with_overriden_equals().Typed_equals(new Struct_of_value_fields_with_overriden_equals());
        }

        [Benchmark]
        public void Equality_comparer_equals__on__structs_of_reference_fields__with__equatable_interface()
        {
            EqualityComparer<Struct_of_reference_fields_with_equatable_interface>.Default.Equals(
                new Struct_of_reference_fields_with_equatable_interface(),
                new Struct_of_reference_fields_with_equatable_interface());
        }

        [Benchmark]
        public void Equality_comparer_equals__on__structs_of_value_fields__with__equatable_interface()
        {
            EqualityComparer<Struct_of_value_fields_with_equatable_interface>.Default.Equals(
                new Struct_of_value_fields_with_equatable_interface(),
                new Struct_of_value_fields_with_equatable_interface());
        }

        [Benchmark]
        public void Equality_comparer_equals__on__structs_of_mixed_fields__with__equatable_interface()
        {
            EqualityComparer<Struct_of_mixed_fields_with_equatable_interface>.Default.Equals(
                new Struct_of_mixed_fields_with_equatable_interface(),
                new Struct_of_mixed_fields_with_equatable_interface());
        }

        private class Config : ManualConfig
        {
            public Config()
            {
                var separators = new[] { "__on__", "__with__" };
                Add(new ChangeId("Comparison", new LowerValueCase(new TagColumn("Comparison", name => new ColumnName(name).NthToken(0, separators)))));
                Add(new ChangeId("Type", new SingularizeValue(new TagColumn("Type", name => new ColumnName(name).NthToken(1, separators)))));
                Add(new ChangeId("Implementation", new TagColumn("Implementation", name => new ColumnName(name).NthToken(2, separators))));
            }
        }
    }
}

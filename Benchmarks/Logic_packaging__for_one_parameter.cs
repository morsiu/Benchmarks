using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Jobs;
using System;

namespace DotNetPerf.Benchmarks
{
    [Config(typeof(Config))]
    public class Logic_packaging__for_one_parameter
    {
        public static class Logic_in_static_method
        {
            public static int Logic(int x)
            {
                return x;
            }
        }

        public struct Logic_in_structure
        {
            private readonly int _x;

            public Logic_in_structure(int x)
            {
                _x = x;
            }

            public int Logic()
            {
                return _x;
            }
        }

        public class Logic_in_class
        {
            private readonly int _x;

            public Logic_in_class(int x)
            {
                _x = x;
            }

            public int Logic()
            {
                return _x;
            }
        }

        [Benchmark]
        public int Logic__in__Logic_in_class()
        {
            return new Logic_in_class(5)
                .Logic();
        }

        [Benchmark]
        public int Logic__in__Logic_in_struct()
        {
            return new Logic_in_structure(5)
                .Logic();
        }

        [Benchmark]
        public int Logic__in__Logic_in_static_method()
        {
            return Logic_in_static_method
                .Logic(5);
        }

        public sealed class Config : ManualConfig
        {
            public Config()
            {
                Add(new MemoryDiagnoser());
                Add(Job.LegacyJitX86);
                Add(Job.LegacyJitX64);
                Add(Job.RyuJitX64);
            }
        }
    }
}

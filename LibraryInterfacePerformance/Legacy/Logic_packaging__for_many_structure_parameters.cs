using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Jobs;

namespace LibraryInterfacePerformance.Legacy
{
    [Config(typeof(Config))]
    public class Logic_packaging__for_many_structure_parameters
    {
        public static class Logic_in_static_method
        {
            public static DateTime Logic(DateTime xStart, DateTime xEnd, DateTime yStart, DateTime yEnd)
            {
                return xStart;
            }
        }

        public struct Logic_in_structure
        {
            private readonly DateTime _xStart;
            private readonly DateTime _xEnd;
            private readonly DateTime _yStart;
            private readonly DateTime _yEnd;

            public Logic_in_structure(DateTime xStart, DateTime xEnd, DateTime yStart, DateTime yEnd)
            {
                _xStart = xStart;
                _xEnd = xEnd;
                _yStart = yStart;
                _yEnd = yEnd;
            }

            public DateTime Logic()
            {
                return _xStart;
            }
        }

        public class Logic_in_class
        {
            private readonly DateTime _xStart;
            private readonly DateTime _xEnd;
            private readonly DateTime _yStart;
            private readonly DateTime _yEnd;

            public Logic_in_class(DateTime xStart, DateTime xEnd, DateTime yStart, DateTime yEnd)
            {
                _xStart = xStart;
                _xEnd = xEnd;
                _yStart = yStart;
                _yEnd = yEnd;
            }

            public DateTime Logic()
            {
                return _xStart;
            }
        }

        [GlobalSetup]
        public void SetupParameters()
        {
            _xStart = new DateTime(1000, 1, 1);
            _xEnd = new DateTime(2000, 1, 1);
            _yStart = new DateTime(500, 1, 1);
            _yEnd = new DateTime(1500, 1, 1);
        }

        private DateTime _xStart;
        private DateTime _xEnd;
        private DateTime _yStart;
        private DateTime _yEnd;

        [Benchmark]
        public DateTime Logic__in__Logic_in_class()
        {
            return new Logic_in_class(_xStart, _xEnd, _yStart, _yEnd)
                .Logic();
        }

        [Benchmark]
        public DateTime Logic__in__Logic_in_struct()
        {
            return new Logic_in_structure(_xStart, _xEnd, _yStart, _yEnd)
                .Logic();
        }

        [Benchmark]
        public DateTime Logic__in__Logic_in_static_method()
        {
            return Logic_in_static_method
                .Logic(_xStart, _xEnd, _yStart, _yEnd);
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

using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;

namespace QueryableOverhead
{
    [Config(typeof(OverheadConfig))]
    public class EnumerableAsQueryableOverhead
    {
        [GlobalSetup]
        public void GlobalSetup()
        {
            Entities = Enumerable.Repeat(10, 100).Select(x => new Entity { Property = x }).ToList();
        }

        public List<Entity> Entities { get; set; }

        [Benchmark]
        public IEnumerable<Entity> FilterEnumerable()
        {
            return Entities.Where(x => x.Property == 10).ToList();
        }

        [Benchmark]
        public IEnumerable<Entity> FilterQueryable()
        {
            return Entities.AsQueryable().Where(x => x.Property == 10).ToList();
        }

        public class Entity
        {
            public int Property { get; set; }
        }
    }
}

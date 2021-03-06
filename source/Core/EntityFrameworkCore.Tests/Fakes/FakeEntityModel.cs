using System.Collections.Generic;

namespace Solution.Core.EntityFrameworkCore.Tests
{
    public class FakeEntityModel
    {
        public long FakeEntityId { get; set; }

        public string Name { get; set; }

        public ICollection<FakeEntityChild> FakeEntityChild { get; set; } = new HashSet<FakeEntityChild>();
    }
}

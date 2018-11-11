using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.Core.MongoDB.Tests
{
    public sealed class FakeRepository : MongoRepository<FakeDocument>, IFakeRepository
    {
        public FakeRepository(FakeContext context) : base(context)
        {
        }
    }
}

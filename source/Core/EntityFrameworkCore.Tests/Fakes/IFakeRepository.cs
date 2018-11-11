using Solution.Core.Databases;

namespace Solution.Core.EntityFrameworkCore.Tests
{
    public interface IFakeRepository : IRelationalRepository<FakeEntity>
    {
    }
}

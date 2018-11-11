using Solution.Core.Databases;
using Solution.App.Model.Entities;

namespace Solution.App.Database
{
    public interface IUserLogRepository : IRelationalRepository<UserLogEntity> { }
}

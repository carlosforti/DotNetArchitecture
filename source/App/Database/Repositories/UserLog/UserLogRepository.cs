using Solution.Core.EntityFrameworkCore;
using Solution.App.Model.Entities;

namespace Solution.App.Database
{
    public sealed class UserLogRepository : EntityFrameworkCoreRepository<UserLogEntity>, IUserLogRepository
    {
        public UserLogRepository(DatabaseContext context) : base(context) { }
    }
}

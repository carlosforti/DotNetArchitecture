using Solution.App.Model.Entities;
using Solution.App.Model.Enums;
using System;

namespace Solution.App.Domain
{
    public class UserLogFactory : IUserLogFactory
    {
        public UserLogEntity Create(long userId, LogType logType)
        {
            return new UserLogEntity
            {
                UserId = userId,
                LogType = logType,
                DateTime = DateTime.UtcNow
            };
        }
    }
}

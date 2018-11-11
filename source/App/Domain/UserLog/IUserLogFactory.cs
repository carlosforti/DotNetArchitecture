using Solution.App.Model.Entities;
using Solution.App.Model.Enums;

namespace Solution.App.Domain
{
    public interface IUserLogFactory
    {
        UserLogEntity Create(long userId, LogType logType);
    }
}

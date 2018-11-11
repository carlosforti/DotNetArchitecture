using Solution.App.Model.Enums;

namespace Solution.App.Domain
{
    public interface IUserLogDomain
    {
        void Save(long userId, LogType logType);
    }
}

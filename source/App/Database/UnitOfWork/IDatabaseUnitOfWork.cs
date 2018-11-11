namespace Solution.App.Database
{
    public interface IDatabaseUnitOfWork
    {
        IUserLogRepository UserLogRepository { get; }

        IUserRepository UserRepository { get; }

        void SaveChanges();
    }
}

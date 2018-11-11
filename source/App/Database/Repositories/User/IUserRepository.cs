using Solution.Core.Databases;
using Solution.App.Model.Entities;
using Solution.App.Model.Models;

namespace Solution.App.Database
{
    public interface IUserRepository : IRelationalRepository<UserEntity>
    {
        SignedInModel SignIn(SignInModel signIn);
    }
}

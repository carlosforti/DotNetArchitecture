using Solution.Core.EntityFrameworkCore;
using Solution.App.Model.Entities;
using Solution.App.Model.Enums;
using Solution.App.Model.Models;

namespace Solution.App.Database
{
    public sealed class UserRepository : EntityFrameworkCoreRepository<UserEntity>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context) { }

        public SignedInModel SignIn(SignInModel signIn)
        {
            return SingleOrDefault<SignedInModel>
            (
                user => user.Login.Equals(signIn.Login)
                && user.Password.Equals(signIn.Password)
                && user.Status == Status.Active
            );
        }
    }
}

using Solution.Core.Security;
using Solution.App.Database;
using Solution.App.Model.Enums;
using Solution.App.Model.Models;
using Solution.App.Model.Validators;

namespace Solution.App.Domain
{
    public sealed class AuthenticationDomain : IAuthenticationDomain
    {
        public AuthenticationDomain(
            IDatabaseUnitOfWork databaseUnitOfWork,
            IHash hash,
            IJsonWebToken jsonWebToken,
            IUserLogDomain userLogDomain)
        {
            DatabaseUnitOfWork = databaseUnitOfWork;
            Hash = hash;
            JsonWebToken = jsonWebToken;
            UserLogDomain = userLogDomain;
        }

        private IDatabaseUnitOfWork DatabaseUnitOfWork { get; }
        private IHash Hash { get; }
        private IJsonWebToken JsonWebToken { get; }
        private IUserLogDomain UserLogDomain { get; }

        public string SignIn(SignInModel signIn)
        {
            new SignInValidator().ValidateThrow(signIn);

            CreateHash(signIn);

            var signedIn = DatabaseUnitOfWork.UserRepository.SignIn(signIn);

            new SignedInValidator().ValidateThrow(signedIn);

            UserLogDomain.Save(signedIn.UserId, LogType.Login);

            return CreateJwt(signedIn);
        }

        public void SignOut(SignOutModel signOut)
        {
            UserLogDomain.Save(signOut.UserId, LogType.Logout);
        }

        private void CreateHash(SignInModel signIn)
        {
            signIn.Login = Hash.Create(signIn.Login);
            signIn.Password = Hash.Create(signIn.Password);
        }

        private string CreateJwt(SignedInModel signedIn)
        {
            var sub = signedIn.UserId.ToString();
            var roles = signedIn.Roles.ToString().Split(", ");

            return JsonWebToken.Encode(sub, roles);
        }
    }
}

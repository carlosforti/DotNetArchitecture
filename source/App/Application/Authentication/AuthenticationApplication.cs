using Solution.App.Domain;
using Solution.App.Model.Models;

namespace Solution.App.Application
{
    public sealed class AuthenticationApplication : IAuthenticationApplication
    {
        public AuthenticationApplication(IAuthenticationDomain authenticationDomain)
        {
            AuthenticationDomain = authenticationDomain;
        }

        private IAuthenticationDomain AuthenticationDomain { get; }

        public string SignIn(SignInModel signIn)
        {
            return AuthenticationDomain.SignIn(signIn);
        }

        public void SignOut(SignOutModel signOut)
        {
            AuthenticationDomain.SignOut(signOut);
        }
    }
}

using Solution.App.Model.Models;

namespace Solution.App.Domain
{
    public interface IAuthenticationDomain
    {
        string SignIn(SignInModel signIn);

        void SignOut(SignOutModel signOut);
    }
}

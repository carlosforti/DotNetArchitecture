using Solution.App.Model.Models;

namespace Solution.App.Application
{
    public interface IAuthenticationApplication
    {
        string SignIn(SignInModel signIn);

        void SignOut(SignOutModel signOut);
    }
}

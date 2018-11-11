using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solution.App.Application;
using Solution.Core.AspNetCore;
using Solution.Core.Extensions;
using Solution.App.Model.Models;

namespace Solution.App.Web
{
    [ApiController]
    [RouteController]
    public class AuthenticationController : ControllerBase
    {
        public AuthenticationController(IAuthenticationApplication authenticationApplication)
        {
            AuthenticationApplication = authenticationApplication;
        }

        private IAuthenticationApplication AuthenticationApplication { get; }

        [AllowAnonymous]
        [HttpPost("[action]")]
        public string SignIn(SignInModel signIn)
        {
            return AuthenticationApplication.SignIn(signIn);
        }

        [HttpPost("[action]")]
        public void SignOut()
        {
            var signOutModel = new SignOutModel(User.ClaimNameIdentifierValue());
            AuthenticationApplication.SignOut(signOutModel);
        }
    }
}

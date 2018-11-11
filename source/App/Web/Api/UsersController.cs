using Microsoft.AspNetCore.Mvc;
using Solution.App.Application;
using Solution.Core.AspNetCore;
using Solution.App.Model.Models;
using System.Collections.Generic;

namespace Solution.App.Web
{
    [ApiController]
    [RouteController]
    public class UsersController : ControllerBase
    {
        public UsersController(IUserApplication userApplication)
        {
            UserApplication = userApplication;
        }

        private IUserApplication UserApplication { get; }

        [HttpGet]
        public IEnumerable<UserModel> Get()
        {
            return UserApplication.List();
        }

        [HttpGet("{id}")]
        public UserModel Get(long id)
        {
            return UserApplication.Select(id);
        }
    }
}

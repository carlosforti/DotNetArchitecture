using Microsoft.AspNetCore.Mvc;
using Solution.Core.AspNetCore;
using Solution.App.Model.Models;

namespace Solution.App.Web
{
    [ApiController]
    [RouteController]
    public class ApplicationController : ControllerBase
    {
        [HttpGet]
        public ApplicationModel Get()
        {
            return new ApplicationModel();
        }
    }
}

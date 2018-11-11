using Solution.Core.Objects;
using Solution.App.Model.Models;
using System.Collections.Generic;

namespace Solution.App.Application
{
    public interface IUserApplication
    {
        PagedList<UserModel> List(PagedListParameters parameters);

        IEnumerable<UserModel> List();

        UserModel Select(long userId);
    }
}

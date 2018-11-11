using Solution.Core.Objects;
using Solution.App.Model.Models;
using System.Collections.Generic;

namespace Solution.App.Domain
{
    public interface IUserDomain
    {
        PagedList<UserModel> List(PagedListParameters parameters);

        IEnumerable<UserModel> List();

        UserModel Select(long userId);
    }
}

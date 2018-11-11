using Microsoft.EntityFrameworkCore;
using Solution.Core.Security;
using Solution.App.Model.Entities;
using Solution.App.Model.Enums;

namespace Solution.App.Database
{
    public static class DatabaseContextSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var hash = new Hash();

            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                UserId = 1,
                Name = "Administrator",
                Surname = "Administrator",
                Email = "administrator@administrator.com",
                Login = hash.Create("admin"),
                Password = hash.Create("admin"),
                Roles = Roles.User | Roles.Admin,
                Status = Status.Active
            });
        }
    }
}

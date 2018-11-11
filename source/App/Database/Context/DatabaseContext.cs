using Microsoft.EntityFrameworkCore;
using Solution.Core.EntityFrameworkCore;

namespace Solution.App.Database
{
    public sealed class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly();
            DatabaseContextSeed.Seed(modelBuilder);
        }
    }
}

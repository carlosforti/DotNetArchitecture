using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Solution.App.Database;
using Solution.App.IoC;
using System;

namespace Solution.App.Web
{
    public static class Extensions
    {
        public static void AddDependencyInjectionCustom(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterServices();
            services.AddCriptography(Guid.NewGuid().ToString());
            services.AddJsonWebTokenSettings(Guid.NewGuid().ToString());
            services.AddLogger(configuration);
            services.AddDbContext<DatabaseContext>(configuration.GetConnectionString(nameof(DatabaseContext)));
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Solution.App.Application;
using Solution.Core.Logging;
using Solution.Core.Security;
using Solution.App.Database;
using Solution.App.Domain;

namespace Solution.App.IoC
{
    public static class IServiceCollectionExtensions
    {
        public static void AddCriptography(this IServiceCollection services, string key)
        {
            services.AddSingleton<ICriptography>(_ => new Criptography(key));
        }

        public static void AddDbContext<T>(this IServiceCollection services, string connectionString) where T : DbContext
        {
            services.AddDbContextPool<T>(options => options.UseSqlServer(connectionString));
            var context = services.GetService<T>();
            context.Database.EnsureCreated();
            context.Database.Migrate();
        }

        public static void AddDbContextInMemoryDatabase<T>(this IServiceCollection services) where T : DbContext
        {
            services.AddDbContextPool<T>(options => options.UseInMemoryDatabase(typeof(T).Name));
            services.GetService<T>().Database.EnsureCreated();
        }

        public static void AddJsonWebTokenSettings(this IServiceCollection services, string key)
        {
            services.AddSingleton<IJsonWebTokenSettings>(_ => new JsonWebTokenSettings(key));
        }

        public static void AddLogger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ILogger>(_ => new Logger(configuration));
        }

        public static T GetService<T>(this IServiceCollection services)
        {
            return services.BuildServiceProvider().GetService<T>();
        }

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            /// Solution.App.Application
            services.AddScoped<IAuthenticationApplication, AuthenticationApplication>();
            services.AddScoped<IFileApplication, FileApplication>();
            services.AddScoped<IUserApplication, UserApplication>();

            /// Solution.App.CrossCutting
            services.AddSingleton<IHash, Hash>();
            services.AddSingleton<IJsonWebToken, JsonWebToken>();

            /// Solution.App.Domain
            services.AddScoped<IAuthenticationDomain, AuthenticationDomain>();
            services.AddScoped<IFileDomain, FileDomain>();
            services.AddScoped<IUserDomain, UserDomain>();
            services.AddScoped<IUserLogDomain, UserLogDomain>();
            services.AddSingleton<IUserLogFactory, UserLogFactory>();

            /// Solution.App.Database
            services.AddScoped<IDatabaseUnitOfWork, DatabaseUnitOfWork>();
            services.AddScoped<IUserLogRepository, UserLogRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}

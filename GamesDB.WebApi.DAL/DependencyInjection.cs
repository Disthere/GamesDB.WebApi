using GamesDB.WebApi.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace GamesDB.WebApi.DAL
{
   public static class DependencyInjection
    {
        public static IServiceCollection AddSqliteDbConnection(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["SqliteDbConnection"];
            services.AddDbContext<GamesDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<IGamesDbContext>(provider =>
            provider.GetService<GamesDbContext>());
            return services;
        }

        public static IServiceCollection AddSqlServerDbConnection(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["SqlServerDbConnection"];
            services.AddDbContext<GamesDbContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddScoped<IGamesDbContext>(provider =>
            provider.GetService<GamesDbContext>());
            return services;
        }
    }
}

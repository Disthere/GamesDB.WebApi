using GamesDB.WebApi.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace GamesDB.WebApi.DAL
{
   public static class DependencyInjection
    {
        public static IServiceCollection AddDbConnection(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<GamesDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<IGamesDbContext>(provider =>
            provider.GetService<GamesDbContext>());
            return services;
        }
    }
}

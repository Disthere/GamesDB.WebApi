using GamesDB.WebApi.DAL.Interfaces;
using GamesDB.WebApi.DAL.Repositories.GamesAggregate;
using GamesDB.WebApi.Service.Implementations;
using GamesDB.WebApi.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;


namespace GamesDB.WebApi.Service
{
   public static class DependencyInjection
    {
        public static IServiceCollection AddServiceInjection(this IServiceCollection
            services)
        {
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IGameRepository, GameRepository>();

            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IGenreRepository, GenreRepository>();

            services.AddScoped<IDeveloperService, DeveloperService>();
            services.AddScoped<IDeveloperRepository, DeveloperRepository>();

            return services;
        }
    }
}

using GamesDB.WebApi.Domain.Entities.GamesAggregate;
using Microsoft.EntityFrameworkCore;

namespace GamesDB.WebApi.DAL.Interfaces
{
    public interface IGamesDbContext
    {
        DbSet<Game> Games { get; set; }
        DbSet<Developer> Developers { get; set; }
        DbSet<Genre> Genres { get; set; }

    }
}

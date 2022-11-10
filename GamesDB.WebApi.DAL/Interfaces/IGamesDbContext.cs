using GamesDB.WebApi.Domain.Entities.GamesAggregate;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace GamesDB.WebApi.DAL.Interfaces
{
    public interface IGamesDbContext
    {
        DbSet<Game> Games { get; set; }
        DbSet<Developer> Developers { get; set; }
        DbSet<Genre> Genres { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}

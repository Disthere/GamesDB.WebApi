using GamesDB.WebApi.Domain.Entities.GameAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GamesDB.WebApi.DAL.Interfaces
{
    public interface IGamesDbContext
    {
        DbSet<Game> Games { get; set; }
        DbSet<Developer> Developers { get; set; }
        DbSet<Genre> Genres { get; set; }

        //Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

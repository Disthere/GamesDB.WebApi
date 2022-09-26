using GamesDB.WebApi.Domain.Entities.GamesAggregate;
using GamesDB.WebApi.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace GamesDB.WebApi.DAL
{
    public class GamesDbContext : DbContext, IGamesDbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public GamesDbContext(DbContextOptions<GamesDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        
    }
}

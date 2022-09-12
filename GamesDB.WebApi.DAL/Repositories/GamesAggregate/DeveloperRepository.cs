using GamesDB.WebApi.DAL.Interfaces;
using GamesDB.WebApi.Domain.Entities.GamesAggregate;


namespace GamesDB.WebApi.DAL.Repositories.GamesAggregate
{
   public class DeveloperRepository : BaseRepository<Developer>, IDeveloperRepository
    {
        public DeveloperRepository(GamesDbContext context) : base(context)
        {
        }
        
    }
}

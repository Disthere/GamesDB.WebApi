using GamesDB.WebApi.DAL.Interfaces;
using GamesDB.WebApi.Domain.Entities.GamesAggregate;


namespace GamesDB.WebApi.DAL.Repositories.GamesAggregate
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(GamesDbContext context) : base(context)
        {

        }
    }
}

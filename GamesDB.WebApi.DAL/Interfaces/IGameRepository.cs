using GamesDB.WebApi.Domain.Entities.GamesAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesDB.WebApi.DAL.Interfaces
{
    public interface IGameRepository : IBaseRepository<Game>
    {
        Task<IEnumerable<Game>> GetByGenre(int genreId);
    }
}

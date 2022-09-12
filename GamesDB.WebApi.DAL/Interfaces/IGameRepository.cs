using GamesDB.WebApi.DAL.Repositories;
using GamesDB.WebApi.Domain.Entities.GamesAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesDB.WebApi.DAL.Interfaces
{
    public interface IGameRepository : IBaseRepository<Game>
    {
        Task<IEnumerable<Game>> GetByGenre(int genreId);
    }
}

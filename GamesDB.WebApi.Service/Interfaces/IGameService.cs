using GamesDB.WebApi.Domain.DbResponse;
using GamesDB.WebApi.Service.ViewModels.GameAggregateViewModels;
using GamesDB.WebApi.Service.ViewModels.HttpResponses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesDB.WebApi.Service.Interfaces
{
    public interface IGameService 
    {
        Task<IBaseDbResponse<bool>> Add(GameViewModel entity);

        Task<IBaseDbResponse<bool>> Update(GameViewModel entity);

        Task<IBaseDbResponse<bool>> Delete(int id);

        Task<IBaseDbResponse<GameResponse>> Get(int id);

        Task<IBaseDbResponse<IEnumerable<GameResponse>>> GetAll();

        Task<IBaseDbResponse<IEnumerable<GameResponse>>> GetByGenre(int genreId);
    }
}

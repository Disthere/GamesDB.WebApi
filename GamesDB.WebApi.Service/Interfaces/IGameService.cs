using GamesDB.WebApi.Domain.Entities.GamesAggregate;
using GamesDB.WebApi.Domain.Response;
using GamesDB.WebApi.Service.ViewModels.GameAggregateViewModels;
using GamesDB.WebApi.Service.ViewModels.HttpResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesDB.WebApi.Service.Interfaces
{
    public interface IGameService 
    {
        Task<IBaseResponse<bool>> Add(GameViewModel entity);

        Task<IBaseResponse<bool>> Update(GameViewModel entity);

        Task<IBaseResponse<bool>> Delete(int id);

        Task<IBaseResponse<GameResponse>> Get(int id);

        Task<IBaseResponse<IEnumerable<GameResponse>>> GetAll();
    }
}

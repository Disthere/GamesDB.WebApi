using GamesDB.WebApi.Domain.Entities.GamesAggregate;
using GamesDB.WebApi.Domain.DbResponse;
using GamesDB.WebApi.Service.ViewModels.GameAggregateViewModels;
using GamesDB.WebApi.Service.ViewModels.HttpResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesDB.WebApi.Service.Interfaces
{
    public interface IGenreService 
    {
        Task<IBaseDbResponse<bool>> Add(GenreViewModel entity);

        Task<IBaseDbResponse<bool>> Update(GenreViewModel entity);

        Task<IBaseDbResponse<bool>> Delete(int id);

        Task<IBaseDbResponse<GenreResponse>> Get(int id);

        Task<IBaseDbResponse<IEnumerable<GenreResponse>>> GetAll();
    }
}

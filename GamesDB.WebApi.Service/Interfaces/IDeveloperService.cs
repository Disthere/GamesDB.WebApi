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
    public interface IDeveloperService 
    {
        Task<IBaseDbResponse<bool>> Add(DeveloperViewModel entity);

        Task<IBaseDbResponse<bool>> Update(DeveloperViewModel entity);

        Task<IBaseDbResponse<bool>> Delete(int id);

        Task<IBaseDbResponse<DeveloperResponse>> Get(int id);

        Task<IBaseDbResponse<IEnumerable<DeveloperResponse>>> GetAll();
    }
}

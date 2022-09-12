using GamesDB.WebApi.Domain.Entities;
using GamesDB.WebApi.Domain.DbResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesDB.WebApi.Service.Interfaces
{
    public interface IBaseService<V>
    {
        Task<IBaseDbResponse<V>> Add(V entity);

        Task<IBaseDbResponse<V>> Update(V entity);

        Task<IBaseDbResponse<V>> Delete(V entity);

        Task<IBaseDbResponse<V>> Get(int id);

        Task<IBaseDbResponse<IEnumerable<V>>> GetAll();
    }
}

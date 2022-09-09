using GamesDB.WebApi.Domain.Entities;
using GamesDB.WebApi.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesDB.WebApi.Service.Interfaces
{
    public interface IBaseService<M,V>
    {
        Task<IBaseResponse<V>> Add(V entity);

        Task<IBaseResponse<V>> Update(V entity);

        Task<IBaseResponse<V>> Delete(V entity);

        Task<IBaseResponse<V>> Get(int id);

        Task<IBaseResponse<IEnumerable<V>>> GetAll();
    }
}

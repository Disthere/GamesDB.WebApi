using GamesDB.WebApi.Domain.Entities;
using GamesDB.WebApi.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesDB.WebApi.Service.Interfaces
{
    public interface IBaseService<T>
    {
        Task<IBaseResponse<T>> Add(T entity);

        Task<IBaseResponse<T>> Update(T entity);

        Task<IBaseResponse<T>> Delete(T entity);

        Task<IBaseResponse<T>> Get(int id);

        Task<IBaseResponse<IEnumerable<T>>> GetAll();
    }
}

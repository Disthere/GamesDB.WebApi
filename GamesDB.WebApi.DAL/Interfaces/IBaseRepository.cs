using GamesDB.WebApi.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesDB.WebApi.DAL.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<bool> Add(T entity);

        Task<bool> Update(T entity);

        Task<bool> Delete(T entity);

        Task<T> Get(int id);

        Task<IEnumerable<T>> GetAll();
    }
}

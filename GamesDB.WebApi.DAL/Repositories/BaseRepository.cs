using GamesDB.WebApi.DAL.Interfaces;
using GamesDB.WebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesDB.WebApi.DAL.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly GamesDbContext _context;

        public BaseRepository(GamesDbContext context) =>
        _context = context;

        public async Task<bool> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(T entity)
        {
            _context.Set<T>().Remove(entity);

            await _context.SaveChangesAsync();

            return true;
        }

        public virtual async Task<T> Get(int id)
        {
            T entity;

            entity = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);

            return entity;
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            IEnumerable<T> entityList;

            entityList = await _context.Set<T>().ToListAsync();

            return entityList;
        }

        public async Task<bool> Update(T entity)
        {
            _context.Set<T>().Update(entity);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}

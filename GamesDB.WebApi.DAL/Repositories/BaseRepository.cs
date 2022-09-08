using GamesDB.WebApi.DAL.Interfaces;
using GamesDB.WebApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesDB.WebApi.DAL.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        //private readonly DbSet<T> _dbSet;
        private readonly GamesDbContext _context;
        public BaseRepository(GamesDbContext context)
        {
            //_dbSet = context.Set<T>();
            _context = context;
        }
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

        public async Task<T> Get(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<bool> Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

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
        private readonly GamesDbContext _context;
        public BaseRepository(GamesDbContext context)
        {
           _context = context;
        }
        public async Task<bool> Add(T entity)
        {
            using (_context)
            {
                await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();
            }

            return true;
        }

        public async Task<bool> Delete(T entity)
        {
            using (_context)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }

            return true;
        }

        public async Task<T> Get(int id)
        {
            T entity;

            
                entity = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            

            return entity;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            IEnumerable<T> entityList;
            using (_context)
            {
                entityList = await _context.Set<T>().ToListAsync();
            }

            return entityList;
        }

        public async Task<bool> Update(T entity)
        {
            using (_context)
            {
                _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            }
                    
            return true;
        }
    }
}

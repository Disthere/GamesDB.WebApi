using GamesDB.WebApi.DAL.Interfaces;
using GamesDB.WebApi.Domain.Entities.GamesAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesDB.WebApi.DAL.Repositories.GamesAggregate
{
   public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(GamesDbContext context) : base(context)
        {}
            public override async Task<Game> Get(int id)
        {
            Game entity;

            entity = await _context.Set<Game>()
                .Include(c => c.Developer)
                .Include(c => c.Genres)
                .FirstOrDefaultAsync(x => x.Id == id);

            return entity;
        }

        public override async Task<IEnumerable<Game>> GetAll()
        {
            IEnumerable<Game> entityList;

            entityList = await _context.Set<Game>()
                .Include(c => c.Developer)
                .Include(c => c.Genres)
                .ToListAsync();

            return entityList;
        }
    }
       
}

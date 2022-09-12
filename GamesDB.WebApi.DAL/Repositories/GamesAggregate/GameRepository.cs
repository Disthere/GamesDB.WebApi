using GamesDB.WebApi.DAL.Interfaces;
using GamesDB.WebApi.Domain.Entities.GamesAggregate;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesDB.WebApi.DAL.Repositories.GamesAggregate
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(GamesDbContext context) : base(context)
        { }

        public override async Task<Game> Get(int id)
        {
            Game game;

            game = await _context.Set<Game>()
                .Include(c => c.Developer)
                .Include(c => c.Genres)
                .FirstOrDefaultAsync(x => x.Id == id);

            return game;
        }

        public override async Task<IEnumerable<Game>> GetAll()
        {
            IEnumerable<Game> gameList;

            gameList = await _context.Set<Game>()
                .Include(c => c.Developer)
                .Include(c => c.Genres)
                .ToListAsync();

            return gameList;
        }

        public async Task<IEnumerable<Game>> GetByGenre(int genreId)
        {
            IEnumerable<Game> gameList;

            gameList = await _context.Set<Game>()
                .Include(c => c.Developer)
                .Include(c => c.Genres)
                .Where(g => g.Genres.Any(p =>p.Id == genreId))
                .ToListAsync();

            return gameList;
        }
    }

}

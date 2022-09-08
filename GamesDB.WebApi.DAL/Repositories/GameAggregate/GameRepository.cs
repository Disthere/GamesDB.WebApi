using GamesDB.WebApi.Domain.Entities.GameAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesDB.WebApi.DAL.Repositories.GameAggregate
{
   public class GameRepository : BaseRepository<Game>
    {
        public GameRepository(GamesDbContext context) : base(context)
        {
            
        }
       
    }
}

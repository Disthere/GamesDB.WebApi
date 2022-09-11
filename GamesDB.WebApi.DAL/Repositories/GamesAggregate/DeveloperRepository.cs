using GamesDB.WebApi.Domain.Entities.GamesAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesDB.WebApi.DAL.Repositories.GamesAggregate
{
   public class DeveloperRepository : BaseRepository<Developer>
    {
        public DeveloperRepository(GamesDbContext context) : base(context)
        {
        }
        
    }
}

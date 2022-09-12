using GamesDB.WebApi.DAL.Interfaces;
using GamesDB.WebApi.Domain.Entities.GamesAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesDB.WebApi.DAL.Repositories.GamesAggregate
{
   public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(GamesDbContext context) : base(context)
        {
            
        }
    }
}

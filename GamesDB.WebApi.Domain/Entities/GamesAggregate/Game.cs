using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesDB.WebApi.Domain.Entities.GamesAggregate
{
   public class Game : BaseEntity
    {
        public Game()
        {
            this.Genres = new List<Genre>();
        }
        //public int Id { get; set; }
        public string Title { get; set; }
        public int? DeveloperId { get; set; }
        public Developer Developer { get; set; }

        public ICollection<Genre> Genres { get; set; }
    }
}

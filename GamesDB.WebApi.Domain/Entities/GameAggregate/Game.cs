using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesBaseAccess.Domain.GameAggregate
{
   public class Game
    {
        public Game()
        {
            this.Genres = new List<Genre>();
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid? DeveloperId { get; set; }
        public Developer Developer { get; set; }

        public ICollection<Genre> Genres { get; set; }
    }
}

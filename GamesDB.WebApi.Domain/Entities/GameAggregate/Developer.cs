using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesBaseAccess.Domain.GameAggregate
{
   public class Developer
    {
        public Developer()
        {
            this.Games = new List<Game>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}

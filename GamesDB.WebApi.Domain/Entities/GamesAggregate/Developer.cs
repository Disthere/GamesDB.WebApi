using System.Collections.Generic;


namespace GamesDB.WebApi.Domain.Entities.GamesAggregate
{
    public class Developer : BaseEntity
    {
        public Developer()
        {
            this.Games = new List<Game>();
        }

        public string Name { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}

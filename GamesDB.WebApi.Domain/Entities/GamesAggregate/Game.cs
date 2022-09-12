using System.Collections.Generic;


namespace GamesDB.WebApi.Domain.Entities.GamesAggregate
{
    public class Game : BaseEntity
    {
        public Game()
        {
            this.Genres = new List<Genre>();
        }

        public string Title { get; set; }
        public int? DeveloperId { get; set; }
        public Developer Developer { get; set; }
        public ICollection<Genre> Genres { get; set; }
    }
}

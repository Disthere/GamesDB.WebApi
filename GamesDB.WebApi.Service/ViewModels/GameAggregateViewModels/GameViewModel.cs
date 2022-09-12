using GamesDB.WebApi.Domain.Entities.GamesAggregate;
using System.Collections.Generic;


namespace GamesDB.WebApi.Service.ViewModels.GameAggregateViewModels
{
    public class GameViewModel
    {
        public GameViewModel()
        {
            this.Genres = new List<Genre>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public int? DeveloperId { get; set; }
        public Developer Developer { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public List<int> GenresIds { get; set; }
    }
}

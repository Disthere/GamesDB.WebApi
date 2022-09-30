using GamesDB.WebApi.Domain.Entities.GamesAggregate;
using System.Collections.Generic;


namespace GamesDB.WebApi.Service.ViewModels.HttpResponses
{
   public class GameResponse
    {
        public GameResponse(Game game)
        {
            this.Game = game;
            this.Id = game.Id;
            this.Title = game.Title;
            this.DeveloperId = game.DeveloperId;
            this.Genres = new List<string>();
            this.GenresIds = new List<int>();
            InitializeDeveloper();
            InitializeGenres();
        }
        private Game Game { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public int? DeveloperId { get; set; }
        public string Developer { get; set; }
        public ICollection<int> GenresIds { get; set; }
        public ICollection<string> Genres { get; set; }

        private void InitializeDeveloper()
        {
            this.Developer = Game.Developer?.Name;
        }

        private void InitializeGenres()
        {
            if (Game.Genres.Count != 0)
            {
                foreach (var genre in this.Game.Genres)
                {
                    this.Genres.Add(genre.Name);
                    this.GenresIds.Add(genre.Id);
                }
            }
        }

    }
}

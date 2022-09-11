using GamesDB.WebApi.Domain.Entities.GamesAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            GetDeveloper();
            GetGenres();
        }
        private Game Game { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public int? DeveloperId { get; set; }
        public string Developer { get; set; }
        public ICollection<int> GenresIds { get; set; }
        public ICollection<string> Genres { get; set; }

        private void GetDeveloper()
        {
            this.Developer = Game.Developer?.Name;
        }

        private void GetGenres()
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

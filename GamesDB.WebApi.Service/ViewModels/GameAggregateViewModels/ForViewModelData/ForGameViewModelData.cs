using GamesDB.WebApi.DAL;
using GamesDB.WebApi.DAL.Repositories.GamesAggregate;
using GamesDB.WebApi.Domain.Entities.GamesAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesDB.WebApi.Service.ViewModels.GameAggregateViewModels.ForViewModelData
{
    /// <summary>
    /// Класс используется для получения объектов типов Genre (список) и Developer
    /// при добавлении и обновлении в базе данных объектов типа Game
    /// </summary>
    public class ForGameViewModelData
    {
        private GameViewModel _gameViewModel { get; set; }
        private readonly GamesDbContext _dbContext;

        public ForGameViewModelData(GameViewModel gameViewModel, GamesDbContext dbContext) =>
             (_gameViewModel, _dbContext) = (gameViewModel, dbContext);

        public Task<Developer> GetDeveloper()
        {
            if (_gameViewModel.DeveloperId != null)
            {
                int developerId = (int)_gameViewModel.DeveloperId;
                var developer = new DeveloperRepository(_dbContext).Get(developerId);
                return developer;
            }

            return null;
        }

        public List<Genre> GetGenresList()
        {
            var genresIdsList = _gameViewModel.GenresIds;

            var genresList = new List<Genre>();

            if (genresIdsList != null)
            {
                foreach (var genreId in genresIdsList)
                {
                    var genre = new GenreRepository(_dbContext).Get(genreId).Result;
                    genresList.Add(genre);
                }
            }

            return genresList;
        }
    }
}

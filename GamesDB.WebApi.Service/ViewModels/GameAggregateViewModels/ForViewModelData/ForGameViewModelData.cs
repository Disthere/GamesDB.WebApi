using GamesDB.WebApi.DAL;
using GamesDB.WebApi.DAL.Repositories;
using GamesDB.WebApi.Domain.Entities.GameAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesDB.WebApi.Service.ViewModels.GameAggregateViewModels.ForViewModelData
{
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
                var developer = new BaseRepository<Developer>(_dbContext).Get(developerId);
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
                    var genre = new BaseRepository<Genre>(_dbContext).Get(genreId).Result;
                    genresList.Add(genre);
                }
            }

            return genresList;
        }
    }
}

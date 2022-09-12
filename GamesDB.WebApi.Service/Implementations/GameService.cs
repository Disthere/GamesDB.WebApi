using AutoMapper;
using GamesDB.WebApi.DAL;
using GamesDB.WebApi.DAL.Interfaces;
using GamesDB.WebApi.Domain.Entities.GamesAggregate;
using GamesDB.WebApi.Domain.Enums;
using GamesDB.WebApi.Domain.DbResponse;
using GamesDB.WebApi.Service.Interfaces;
using GamesDB.WebApi.Service.ViewModels.GameAggregateViewModels;
using GamesDB.WebApi.Service.ViewModels.GameAggregateViewModels.ForViewModelData;
using GamesDB.WebApi.Service.ViewModels.HttpResponses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesDB.WebApi.Service.Implementations
{
    public class GameService : IGameService
    {
        private readonly IMapper _mapper;
        private readonly IGameRepository _gameRepository;
        private readonly GamesDbContext _dbContext;

        public GameService(IGameRepository gameRepository, IMapper mapper, GamesDbContext dbContext) =>
           (_gameRepository, _mapper, _dbContext) = (gameRepository, mapper, dbContext);

        #region Добавить новую игру
        public async Task<IBaseDbResponse<bool>> Add(GameViewModel entity)
        {
            Game addingGame = _mapper.Map<Game>(entity);

            ForGameViewModelData data = new(entity, _dbContext);

            var developer = await data.GetDeveloper();
            addingGame.Developer = developer;

            var genres = data.GetGenresList();
            addingGame.Genres = genres;

            var baseResponse = new BaseDbResponse<bool>();

            try
            {
                await _gameRepository.Add(addingGame);
                baseResponse.Data = true;
                baseResponse.StatusCode = RequestToDbErrorStatusCode.Success;
            }
            catch (Exception ex)
            {
                return new BaseDbResponse<bool>()
                {
                    Description = $"[Add] : {ex.Message}",
                    StatusCode = RequestToDbErrorStatusCode.InternalServerError
                };
            }
            return baseResponse;
        }
        #endregion

        #region Получить информацию об игре из базы данных
        public async Task<IBaseDbResponse<GameResponse>> Get(int id)
        {
            var baseResponse = new BaseDbResponse<GameResponse>();

            try
            {
                var extractableGame = await _gameRepository.Get(id);

                if (extractableGame == null)
                {
                    baseResponse.Description = "Object not found";
                    baseResponse.StatusCode = RequestToDbErrorStatusCode.NotFound;
                    return baseResponse;
                }

                baseResponse.Data = new GameResponse(extractableGame);
                baseResponse.StatusCode = RequestToDbErrorStatusCode.Success;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseDbResponse<GameResponse>()
                {
                    Description = $"[GetById] : {ex.Message}",
                    StatusCode = RequestToDbErrorStatusCode.InternalServerError,
                };
            }
        }
        #endregion

        #region Получить список всех игр из базы данных
        public async Task<IBaseDbResponse<IEnumerable<GameResponse>>> GetAll()
        {
            var baseResponse = new BaseDbResponse<IEnumerable<GameResponse>>();

            try
            {
                var games = await _gameRepository.GetAll();

                if (games == null)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = RequestToDbErrorStatusCode.NotFound;
                    return baseResponse;
                }

                var gameResponses = new List<GameResponse>();

                foreach (var game in games)
                {
                    gameResponses.Add(new GameResponse(game));
                }

                baseResponse.Data = gameResponses;

                baseResponse.StatusCode = RequestToDbErrorStatusCode.Success;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseDbResponse<IEnumerable<GameResponse>>()
                {
                    Description = $"[GetAllGames] : {ex.Message}",
                    StatusCode = RequestToDbErrorStatusCode.InternalServerError
                };
            }
        }
        #endregion

        #region Обновить информацию об игре в базе данных
        public async Task<IBaseDbResponse<bool>> Update(GameViewModel entity)
        {
            Game newGame = _mapper.Map<Game>(entity);

            ForGameViewModelData data = new ForGameViewModelData(entity, _dbContext);

            var developer = await data.GetDeveloper();
            newGame.Developer = developer;

            var genres = data.GetGenresList();
            newGame.Genres = genres;

            Game updatingGame = await _gameRepository.Get(newGame.Id);

            {
                updatingGame.Title = newGame.Title;
                updatingGame.DeveloperId = newGame.DeveloperId;
                updatingGame.Developer = newGame.Developer;
                updatingGame.Genres = newGame.Genres;
            }

            var baseResponse = new BaseDbResponse<bool>();

            try
            {
                await _gameRepository.Update(updatingGame);
                baseResponse.Data = true;
                baseResponse.StatusCode = RequestToDbErrorStatusCode.Success;
            }
            catch (Exception ex)
            {
                return new BaseDbResponse<bool>()
                {
                    Description = $"[Update] : {ex.Message}",
                    StatusCode = RequestToDbErrorStatusCode.InternalServerError
                };
            }
            return baseResponse;
        }
        #endregion

        #region Удалить информацию об игре из базы данных
        public async Task<IBaseDbResponse<bool>> Delete(int id)
        {
            var baseResponse = new BaseDbResponse<bool>();

            try
            {
                var deletingGame = await _gameRepository.Get(id);

                if (deletingGame == null)
                {
                    baseResponse.Description = "Object not found";
                    baseResponse.StatusCode = RequestToDbErrorStatusCode.NotFound;
                    return baseResponse;
                }

                await _gameRepository.Delete(deletingGame);
                baseResponse.Data = true;
                baseResponse.StatusCode = RequestToDbErrorStatusCode.Success;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseDbResponse<bool>()
                {
                    Description = $"[Delete] : {ex.Message}",
                    StatusCode = RequestToDbErrorStatusCode.InternalServerError,
                };
            }
        }
        #endregion

        #region Получить список игр из базы данных в соответствии с жанром
        public async Task<IBaseDbResponse<IEnumerable<GameResponse>>> GetByGenre(int genreId)
        {
            var baseResponse = new BaseDbResponse<IEnumerable<GameResponse>>();

            try
            {
                var games = await _gameRepository.GetByGenre(genreId);

                if (games == null)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = RequestToDbErrorStatusCode.NotFound;
                    return baseResponse;
                }

                var gameResponses = new List<GameResponse>();

                foreach (var game in games)
                {
                    gameResponses.Add(new GameResponse(game));
                }

                baseResponse.Data = gameResponses;

                baseResponse.StatusCode = RequestToDbErrorStatusCode.Success;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseDbResponse<IEnumerable<GameResponse>>()
                {
                    Description = $"[GetAllGames] : {ex.Message}",
                    StatusCode = RequestToDbErrorStatusCode.InternalServerError
                };
            }
        }
        #endregion
    }
}

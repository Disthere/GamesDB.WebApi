﻿using AutoMapper;
using GamesDB.WebApi.DAL;
using GamesDB.WebApi.DAL.Interfaces;
using GamesDB.WebApi.DAL.Repositories;
using GamesDB.WebApi.Domain.Entities;
using GamesDB.WebApi.Domain.Entities.GamesAggregate;
using GamesDB.WebApi.Domain.Enums;
using GamesDB.WebApi.Domain.DbResponse;
using GamesDB.WebApi.Service.Interfaces;
using GamesDB.WebApi.Service.ViewModels;
using GamesDB.WebApi.Service.ViewModels.GameAggregateViewModels;
using GamesDB.WebApi.Service.ViewModels.GameAggregateViewModels.ForViewModelData;
using GamesDB.WebApi.Service.ViewModels.HttpResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesDB.WebApi.Service.Implementations
{
    public class GameService : IGameService
    {

        public GameService(IGameRepository gameRepository, IMapper mapper, GamesDbContext dbContext) =>
           (_gameRepository, _mapper, _dbContext) = (gameRepository, mapper, dbContext);


        private readonly IMapper _mapper;
        private readonly IGameRepository _gameRepository;
        private readonly GamesDbContext _dbContext;


        public async Task<IBaseDbResponse<bool>> Add(GameViewModel entity)
        {
            ForGameViewModelData data = new(entity, _dbContext);

            var gameViewModel = entity;

            gameViewModel.Developer = await data.GetDeveloper();

            gameViewModel.Genres = data.GetGenresList();

            var baseResponse = new BaseDbResponse<bool>();

            Game addingGame = _mapper.Map<Game>(gameViewModel);

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

        public async Task<IBaseDbResponse<bool>> Update(GameViewModel entity)
        {
            ForGameViewModelData data = new ForGameViewModelData(entity, _dbContext);

            var gameViewModel = entity;

            gameViewModel.Developer = await data.GetDeveloper();

            gameViewModel.Genres = data.GetGenresList();

            var baseResponse = new BaseDbResponse<bool>();

            Game newGame = _mapper.Map<Game>(gameViewModel);

            Game updatingGame = await _gameRepository.Get(newGame.Id);

            {
                updatingGame.Title = newGame.Title;
                updatingGame.DeveloperId = newGame.DeveloperId;
                updatingGame.Developer = newGame.Developer;
                updatingGame.Genres = newGame.Genres;
            }

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
    }
}

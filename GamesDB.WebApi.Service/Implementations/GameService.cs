using AutoMapper;
using GamesDB.WebApi.DAL;
using GamesDB.WebApi.DAL.Interfaces;
using GamesDB.WebApi.DAL.Repositories;
using GamesDB.WebApi.Domain.Entities;
using GamesDB.WebApi.Domain.Entities.GameAggregate;
using GamesDB.WebApi.Domain.Enums;
using GamesDB.WebApi.Domain.Response;
using GamesDB.WebApi.Service.Interfaces;
using GamesDB.WebApi.Service.ViewModels;
using GamesDB.WebApi.Service.ViewModels.GameAggregateViewModels;
using GamesDB.WebApi.Service.ViewModels.GameAggregateViewModels.ForViewModelData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesDB.WebApi.Service.Implementations
{
    public class GameService : IGameService 
    {
        
        public GameService(IBaseRepository<Game> baseRepository, IMapper mapper, GamesDbContext dbContext) =>
           (_baseRepository, _mapper, _dbContext) = (baseRepository, mapper, dbContext);


        private readonly IMapper _mapper;
        private readonly IBaseRepository<Game> _baseRepository;
        private readonly GamesDbContext _dbContext;

        public async Task<IBaseResponse<GameViewModel>> Add(GameViewModel entity)
        {
            ForGameViewModelData data = new ForGameViewModelData(entity, _dbContext);
                  
            var gameViewModel = entity;
            gameViewModel.Developer = await data.GetDeveloper();
            var genres = data.GetGenresList();
            gameViewModel.Genres = genres; 

            var baseResponse = new BaseResponse<GameViewModel>();

            Game addingObject = _mapper.Map<Game>(gameViewModel);

            try
            {
                await _baseRepository.Add(addingObject);
                baseResponse.Data = gameViewModel;
                baseResponse.StatusCode = RequestToDbErrorStatusCode.Success;
            }
            catch (Exception ex)
            {
                return new BaseResponse<GameViewModel>()
                {
                    Description = $"[Add] : {ex.Message}",
                    StatusCode = RequestToDbErrorStatusCode.InternalServerError
                };
            }
            return baseResponse;
        }

        public Task<IBaseResponse<GameViewModel>> Delete(GameViewModel entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IBaseResponse<GameViewModel>> Get(int id)
        {
            var baseResponse = new BaseResponse<GameViewModel>();

            try
            {
                var extractableObject = await _baseRepository.Get(id);

                if (extractableObject == null)
                {
                    baseResponse.Description = "Object not found";
                    baseResponse.StatusCode = RequestToDbErrorStatusCode.NotFound;
                    return baseResponse;
                }

                baseResponse.Data = _mapper.Map<GameViewModel>(extractableObject);
                baseResponse.StatusCode = RequestToDbErrorStatusCode.Success;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<GameViewModel>()
                {
                    Description = $"[GetById] : {ex.Message}",
                    StatusCode = RequestToDbErrorStatusCode.InternalServerError,
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<GameViewModel>>> GetAll()
        {
            var baseResponse = new BaseResponse<IEnumerable<GameViewModel>>();

            try
            {
                var games = await _baseRepository.GetAll();
                                
                if (games == null)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = RequestToDbErrorStatusCode.NotFound;
                    return baseResponse;
                }

                baseResponse.Data = _mapper.Map<IEnumerable<GameViewModel>>(games);
                
                baseResponse.StatusCode = RequestToDbErrorStatusCode.Success;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<GameViewModel>>()
                {
                    Description = $"[GetAllGames] : {ex.Message}",
                    StatusCode = RequestToDbErrorStatusCode.InternalServerError
                };
            }
        }

        public Task<IBaseResponse<GameViewModel>> Update(GameViewModel entity)
        {
            throw new NotImplementedException();
        }
        //public BaseService(IBaseRepository<T> baseRepository)
        //{
        //    _baseRepository = baseRepository;
        //    _baseEntity = _mapper.Map<BaseEntity>(_baseEntityViewModel);
        //}var ma = _mapper.Map<BaseEntity>(entity);
    }
}

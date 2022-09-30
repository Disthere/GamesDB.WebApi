using AutoMapper;
using GamesDB.WebApi.DAL;
using GamesDB.WebApi.DAL.Interfaces;
using GamesDB.WebApi.Domain.Entities.GamesAggregate;
using GamesDB.WebApi.Domain.Enums;
using GamesDB.WebApi.Domain.DbResponse;
using GamesDB.WebApi.Service.Interfaces;
using GamesDB.WebApi.Service.ViewModels.GameAggregateViewModels;
using GamesDB.WebApi.Service.ViewModels.HttpResponses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamesDB.WebApi.Service.Implementations
{
    public class DeveloperService : IDeveloperService
    {
        private readonly IMapper _mapper;
        private readonly IDeveloperRepository _developerRepository;
        private readonly GamesDbContext _dbContext;

        public DeveloperService(IDeveloperRepository developerRepository, IMapper mapper, GamesDbContext dbContext) =>
           (_developerRepository, _mapper, _dbContext) = (developerRepository, mapper, dbContext);


        #region Добавить нового разработчика в базу данных
        public async Task<IBaseDbResponse<bool>> Add(DeveloperViewModel entity)
        {
            var baseResponse = new BaseDbResponse<bool>();

            Developer addingDeveloper = _mapper.Map<Developer>(entity);

            try
            {
                await _developerRepository.Add(addingDeveloper);
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

        #region Получить информацию о разработчике из базы данных
        public async Task<IBaseDbResponse<DeveloperResponse>> Get(int id)
        {
            var baseResponse = new BaseDbResponse<DeveloperResponse>();

            try
            {
                var extractableDeveloper = await _developerRepository.Get(id);

                if (extractableDeveloper == null)
                {
                    baseResponse.Description = "Object not found";
                    baseResponse.StatusCode = RequestToDbErrorStatusCode.NotFound;
                    return baseResponse;
                }

                baseResponse.Data = new DeveloperResponse(extractableDeveloper);
                baseResponse.StatusCode = RequestToDbErrorStatusCode.Success;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseDbResponse<DeveloperResponse>()
                {
                    Description = $"[GetById] : {ex.Message}",
                    StatusCode = RequestToDbErrorStatusCode.InternalServerError,
                };
            }
        }
        #endregion

        #region Получить список всех разработчиков из базы данных
        public async Task<IBaseDbResponse<IEnumerable<DeveloperResponse>>> GetAll()
        {
            var baseResponse = new BaseDbResponse<IEnumerable<DeveloperResponse>>();

            try
            {
                var developers = await _developerRepository.GetAll();

                if (developers == null)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = RequestToDbErrorStatusCode.NotFound;
                    return baseResponse;
                }

                var developerResponses = new List<DeveloperResponse>();

                foreach (var developer in developers)
                {
                    developerResponses.Add(new DeveloperResponse(developer));
                }

                baseResponse.Data = developerResponses;

                baseResponse.StatusCode = RequestToDbErrorStatusCode.Success;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseDbResponse<IEnumerable<DeveloperResponse>>()
                {
                    Description = $"[GetAll] : {ex.Message}",
                    StatusCode = RequestToDbErrorStatusCode.InternalServerError
                };
            }
        }
        #endregion

        #region Обновить информацию о разработчике в базе данных
        public async Task<IBaseDbResponse<bool>> Update(DeveloperViewModel entity)
        {
            var baseResponse = new BaseDbResponse<bool>();

            Developer updatingDeveloper = await _developerRepository.Get(entity.Id);

            if (updatingDeveloper != null)
            {
                try
                {
                    {
                        updatingDeveloper.Name = entity.Name;
                    }

                    await _developerRepository.Update(updatingDeveloper);
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
            }
            else
            { 
                baseResponse.StatusCode = RequestToDbErrorStatusCode.NotFound; 
            }

            return baseResponse;
        }
        #endregion

        #region Удалить информацию о разработчике из базы данных
        public async Task<IBaseDbResponse<bool>> Delete(int id)
        {
            var baseResponse = new BaseDbResponse<bool>();

            try
            {
                var deletingDeveloper = await _developerRepository.Get(id);

                if (deletingDeveloper == null)
                {
                    baseResponse.Description = "Object not found";
                    baseResponse.StatusCode = RequestToDbErrorStatusCode.NotFound;
                    return baseResponse;
                }

                await _developerRepository.Delete(deletingDeveloper);
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
    }
}

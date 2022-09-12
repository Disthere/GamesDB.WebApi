using AutoMapper;
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
    public class GenreService : IGenreService
    {

        public GenreService(IGenreRepository genreRepository, IMapper mapper, GamesDbContext dbContext) =>
           (_genreRepository, _mapper, _dbContext) = (genreRepository, mapper, dbContext);


        private readonly IMapper _mapper;
        private readonly IGenreRepository _genreRepository;
        private readonly GamesDbContext _dbContext;


        public async Task<IBaseDbResponse<bool>> Add(GenreViewModel entity)
        {
            var baseResponse = new BaseDbResponse<bool>();

            Genre addingGenre = _mapper.Map<Genre>(entity);

            try
            {
                await _genreRepository.Add(addingGenre);
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


        public async Task<IBaseDbResponse<GenreResponse>> Get(int id)
        {
            var baseResponse = new BaseDbResponse<GenreResponse>();

            try
            {
                var extractableGenre = await _genreRepository.Get(id);

                if (extractableGenre == null)
                {
                    baseResponse.Description = "Object not found";
                    baseResponse.StatusCode = RequestToDbErrorStatusCode.NotFound;
                    return baseResponse;
                }

                baseResponse.Data = new GenreResponse(extractableGenre);
                baseResponse.StatusCode = RequestToDbErrorStatusCode.Success;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseDbResponse<GenreResponse>()
                {
                    Description = $"[GetById] : {ex.Message}",
                    StatusCode = RequestToDbErrorStatusCode.InternalServerError,
                };
            }
        }

        public async Task<IBaseDbResponse<IEnumerable<GenreResponse>>> GetAll()
        {
            var baseResponse = new BaseDbResponse<IEnumerable<GenreResponse>>();

            try
            {
                var genres = await _genreRepository.GetAll();

                if (genres == null)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = RequestToDbErrorStatusCode.NotFound;
                    return baseResponse;
                }

                var genreResponses = new List<GenreResponse>();

                foreach (var genre in genres)
                {
                    genreResponses.Add(new GenreResponse(genre));
                }

                baseResponse.Data = genreResponses;

                baseResponse.StatusCode = RequestToDbErrorStatusCode.Success;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseDbResponse<IEnumerable<GenreResponse>>()
                {
                    Description = $"[GetAll] : {ex.Message}",
                    StatusCode = RequestToDbErrorStatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseDbResponse<bool>> Update(GenreViewModel entity)
        {
            var baseResponse = new BaseDbResponse<bool>();

            Genre updatingGenre = await _genreRepository.Get(entity.Id);

            {
                updatingGenre.Name = entity.Name;
            }

            try
            {
                await _genreRepository.Update(updatingGenre);
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
                var deletingGenre = await _genreRepository.Get(id);

                if (deletingGenre == null)
                {
                    baseResponse.Description = "Object not found";
                    baseResponse.StatusCode = RequestToDbErrorStatusCode.NotFound;
                    return baseResponse;
                }

                await _genreRepository.Delete(deletingGenre);
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

    }
}

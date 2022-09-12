﻿using AutoMapper;
using GamesDB.WebApi.DAL.Interfaces;
using GamesDB.WebApi.Domain.Entities;
using GamesDB.WebApi.Domain.Enums;
using GamesDB.WebApi.Domain.DbResponse;
using GamesDB.WebApi.Service.Interfaces;
using GamesDB.WebApi.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesDB.WebApi.Service.Implementations
{
    public abstract class BaseService<M, V> : IBaseService<V> where M : BaseEntity where V : BaseEntityViewModel
    {
        public BaseService(IBaseRepository<M> baseRepository) =>
            (_baseRepository) = (baseRepository);
        

        private readonly IMapper _mapper;
        private readonly IBaseRepository<M> _baseRepository;

        public async Task<IBaseDbResponse<V>> Add(V entity)
        {
            var baseResponse = new BaseDbResponse<V>();

            M addingObject = _mapper.Map<M>(entity);
            try
            {
                await _baseRepository.Add(addingObject);
            }
            catch (Exception ex)
            {
                return new BaseDbResponse<V>()
                {
                    Description = $"[Add] : {ex.Message}",
                    StatusCode = RequestToDbErrorStatusCode.InternalServerError
                };
            }
            return baseResponse;
        }

        public Task<IBaseDbResponse<V>> Delete(V entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IBaseDbResponse<V>> Get(int id)
        {
            var baseResponse = new BaseDbResponse<V>();

            try
            {
                var extractableObject = await _baseRepository.Get(id);

                if (extractableObject == null)
                {
                    baseResponse.Description = "Object not found";
                    baseResponse.StatusCode = RequestToDbErrorStatusCode.NotFound;
                    return baseResponse;
                }

                baseResponse.Data = _mapper.Map<V>(extractableObject); ;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseDbResponse<V>()
                {
                    Description = $"[GetById] : {ex.Message}",
                    StatusCode = RequestToDbErrorStatusCode.InternalServerError,
                };
            }
        }

        public Task<IBaseDbResponse<IEnumerable<V>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IBaseDbResponse<V>> Update(V entity)
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

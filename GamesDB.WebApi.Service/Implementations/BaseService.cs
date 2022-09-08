using AutoMapper;
using GamesDB.WebApi.DAL.Interfaces;
using GamesDB.WebApi.Domain.Entities;
using GamesDB.WebApi.Domain.Response;
using GamesDB.WebApi.Service.Interfaces;
using GamesDB.WebApi.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesDB.WebApi.Service.Implementations
{
    public abstract class BaseService<T> : IBaseService<T> where T : BaseEntityViewModel
    {
        //return _mapper.Map<V>(T);

        private readonly IMapper _mapper;
        private readonly BaseEntity _baseEntity;
        private readonly T _baseEntityViewModel;
        private readonly IBaseRepository<T> _baseRepository;
        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
            _baseEntity = _mapper.Map<BaseEntity>(_baseEntityViewModel);
        }

        public Task<IBaseResponse<T>> Add(T entity)
        {
            var ma = _mapper.Map<BaseEntity>(entity);


            throw new NotImplementedException();
        }

        public Task<IBaseResponse<T>> Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<T>> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<IEnumerable<T>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IBaseResponse<T>> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}

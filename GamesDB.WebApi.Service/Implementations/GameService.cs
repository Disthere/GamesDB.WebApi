using GamesDB.WebApi.DAL.Interfaces;
using GamesDB.WebApi.Domain.Entities;
using GamesDB.WebApi.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesDB.WebApi.Service.Implementations
{
    public class GameService<M, V> : BaseService<M, V> where M : BaseEntity where V : BaseEntityViewModel
    {
        public GameService(IBaseRepository<M> baseRepository) : base(baseRepository)
        {
        }
    }
}

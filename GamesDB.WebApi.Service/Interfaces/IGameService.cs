using GamesDB.WebApi.Domain.Entities.GameAggregate;
using GamesDB.WebApi.Service.ViewModels.GameAggregateViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesDB.WebApi.Service.Interfaces
{
    public interface IGameService : IBaseService<GameViewModel>
    {
    }
}

using GamesDB.WebApi.Domain.Entities;
using GamesDB.WebApi.Domain.Entities.GameAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace GamesDB.WebApi.Service.ViewModels.GameAggregateViewModels
{
    public class DeveloperViewModel : BaseEntityViewModel
    {
        public DeveloperViewModel()
        {
            this.Games = new List<Game>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Game> Games { get; set; }
        
    }
}

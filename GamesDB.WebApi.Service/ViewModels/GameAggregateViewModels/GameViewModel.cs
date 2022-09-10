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
    public class GameViewModel : BaseEntityViewModel
    {
        public GameViewModel()
        {
            this.Genres = new List<Genre>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public int? DeveloperId { get; set; }
        public Developer Developer { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public List<int> GenresIds { get; set; }
    }
}

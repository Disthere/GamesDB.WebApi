using GamesDB.WebApi.DAL.Common.Mappings;
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
    public class GameViewModel : BaseEntityViewModel, IMapWith<Game>
    {
        public GameViewModel()
        {
            this.Genres = new List<GenreViewModel>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public int? DeveloperId { get; set; }
        public DeveloperViewModel Developer { get; set; }
        public ICollection<GenreViewModel> Genres { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Game, GameViewModel>()
                .ForMember(gameVm => gameVm.Id,
                opt => opt.MapFrom(game => game.Id))
                .ForMember(gameVm => gameVm.Title,
                opt => opt.MapFrom(game => game.Title))
                .ForMember(gameVm => gameVm.DeveloperId,
                opt => opt.MapFrom(dev => dev.DeveloperId))
                .ForMember(gameVm => gameVm.Developer,
                opt => opt.MapFrom(game => game.Developer))
                .ForMember(gameVm => gameVm.Genres,
                opt => opt.MapFrom(game => game.Genres));
        }
    }
}

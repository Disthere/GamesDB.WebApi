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
    public class GenreViewModel : BaseEntityViewModel, IMapWith<Genre>
    {
        public GenreViewModel()
        {
            this.Games = new List<GameViewModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<GameViewModel> Games { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Genre, GenreViewModel>()
                .ForMember(genreVm => genreVm.Id,
                opt => opt.MapFrom(genre => genre.Id))
                .ForMember(genreVm => genreVm.Name,
                opt => opt.MapFrom(genre => genre.Name))
                .ForMember(genreVm => genreVm.Games,
                opt => opt.MapFrom(genre => genre.Games));
        }
    }
}

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
   public class DeveloperViewModel : BaseEntityViewModel, IMapWith<Developer>
    {
        public DeveloperViewModel()
        {
            this.Games = new List<GameViewModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<GameViewModel> Games { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Developer, DeveloperViewModel>()
                .ForMember(devVm => devVm.Id,
                opt => opt.MapFrom(dev => dev.Id))
                .ForMember(devVm => devVm.Name,
                opt => opt.MapFrom(dev => dev.Name))
                .ForMember(devVm => devVm.Games,
                opt => opt.MapFrom(dev => dev.Games));

            profile.CreateMap<DeveloperViewModel, Developer>();
        }
    }
}

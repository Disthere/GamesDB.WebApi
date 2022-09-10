using AutoMapper;
using GamesDB.WebApi.Domain.Entities.GameAggregate;
using GamesDB.WebApi.Service.ViewModels.GameAggregateQuery;
using GamesDB.WebApi.Service.ViewModels.GameAggregateViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesDB.WebApi.Service.Mapping
{
    public class GameMappingProfile : Profile
    {
        public GameMappingProfile()
        {
            CreateMap<Game, GameViewModel>()
                .ForMember(gameVm => gameVm.Id,
            opt => opt.MapFrom(game => game.Id))
            .ForMember(gameVm => gameVm.Title,
            opt => opt.MapFrom(game => game.Title))
            .ForMember(gameVm => gameVm.DeveloperId,
            opt => opt.MapFrom(dev => dev.DeveloperId))
            .ForMember(gameVm => gameVm.Developer,
            opt => opt.MapFrom(game => game.Developer))
            .ForMember(gameVm => gameVm.Genres,
            opt => opt.MapFrom(game => game.Genres)).ReverseMap();

            CreateMap<Genre, GenreViewModel>()
                .ForMember(genreVm => genreVm.Id,
                opt => opt.MapFrom(genre => genre.Id))
                .ForMember(genreVm => genreVm.Name,
                opt => opt.MapFrom(genre => genre.Name))
                .ForMember(genreVm => genreVm.Games,
                opt => opt.MapFrom(genre => genre.Games)).ReverseMap();

            CreateMap<Developer, DeveloperViewModel>()
                .ForMember(devVm => devVm.Id,
                opt => opt.MapFrom(dev => dev.Id))
                .ForMember(devVm => devVm.Name,
                opt => opt.MapFrom(dev => dev.Name))
                .ForMember(devVm => devVm.Games,
                opt => opt.MapFrom(dev => dev.Games)).ReverseMap();

            CreateMap<CreateGameQuery, GameViewModel>().ReverseMap();
        }
    }
}

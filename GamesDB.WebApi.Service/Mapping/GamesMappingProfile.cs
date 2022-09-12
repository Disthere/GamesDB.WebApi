using AutoMapper;
using GamesDB.WebApi.Domain.Entities.GamesAggregate;
using GamesDB.WebApi.Service.ViewModels.HttpQuerys;
using GamesDB.WebApi.Service.ViewModels.GameAggregateViewModels;


namespace GamesDB.WebApi.Service.Mapping
{
    public class GamesMappingProfile : Profile
    {
        public GamesMappingProfile()
        {
            CreateMap<Game, GameViewModel>().ReverseMap();
            CreateMap<Genre, GenreViewModel>().ReverseMap();
            CreateMap<Developer, DeveloperViewModel>().ReverseMap();
                
            CreateMap<CreateGameQuery, GameViewModel>().ReverseMap();
            CreateMap<CreateGenreQuery, GenreViewModel>().ReverseMap();
            CreateMap<CreateDeveloperQuery, DeveloperViewModel>().ReverseMap();

            CreateMap<UpdateGameQuery, GameViewModel>().ReverseMap();
            CreateMap<UpdateGenreQuery, GenreViewModel>().ReverseMap();
            CreateMap<UpdateDeveloperQuery, DeveloperViewModel>().ReverseMap();

            CreateMap<Game, Game>().ReverseMap();
            CreateMap<Genre, Genre>().ReverseMap();
            CreateMap<Developer, Developer>().ReverseMap();
        }
    }
}

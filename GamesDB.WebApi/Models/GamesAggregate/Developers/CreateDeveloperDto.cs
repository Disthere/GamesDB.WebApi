using AutoMapper;
using GamesDB.WebApi.DAL.Common.Mappings;
using GamesDB.WebApi.DAL.MediatR.GamesAggregate.Developers.Commands.CreateDeveloper;
using System.ComponentModel.DataAnnotations;

namespace GamesDB.WebApi.Models.GamesAggregate.Developers
{
    public class CreateDeveloperDto : IMapWith<CreateDeveloperCommand>
    {
        [Required]
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateDeveloperDto, CreateDeveloperCommand>()
                .ForMember(developerCommand => developerCommand.Name,
                    opt => opt.MapFrom(developerDto => developerDto.Name));
        }
    }
}

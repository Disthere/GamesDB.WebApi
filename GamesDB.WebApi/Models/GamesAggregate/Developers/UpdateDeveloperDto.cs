using AutoMapper;
using GamesDB.WebApi.DAL.Common.Mappings;
using GamesDB.WebApi.DAL.MediatR.GamesAggregate.Developers.Commands.CreateDeveloper;
using GamesDB.WebApi.DAL.MediatR.GamesAggregate.Developers.Commands.UpdateDeveloper;
using System.ComponentModel.DataAnnotations;

namespace GamesDB.WebApi.Models.GamesAggregate.Developers
{
    public class UpdateDeveloperDto : IMapWith<UpdateDeveloperCommand>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateDeveloperDto, UpdateDeveloperCommand>()
                .ForMember(developerCommand => developerCommand.Id,
                    opt => opt.MapFrom(developerDto => developerDto.Id))
                .ForMember(developerCommand => developerCommand.Name,
                    opt => opt.MapFrom(developerDto => developerDto.Name));
        }
    }
}


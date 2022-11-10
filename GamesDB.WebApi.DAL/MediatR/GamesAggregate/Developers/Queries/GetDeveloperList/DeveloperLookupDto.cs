using AutoMapper;
using GamesDB.WebApi.DAL.Common.Mappings;
using GamesDB.WebApi.DAL.MediatR.GamesAggregate.Developers.Queries.GetDeveloperDetails;
using GamesDB.WebApi.Domain.Entities.GamesAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesDB.WebApi.DAL.MediatR.GamesAggregate.Developers.Queries.GetDeveloperList
{
    public class DeveloperLookupDto : IMapWith<Developer>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Developer, DeveloperLookupDto>()
                .ForMember(developerDto => developerDto.Id,
                opt => opt.MapFrom(developer => developer.Id))
                .ForMember(developerDto => developerDto.Name,
                opt => opt.MapFrom(developer => developer.Name));
        }
    }
}



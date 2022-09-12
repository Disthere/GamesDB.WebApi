using GamesDB.WebApi.Domain.Entities;
using GamesDB.WebApi.Domain.Entities.GamesAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace GamesDB.WebApi.Service.ViewModels.GameAggregateViewModels
{
    public class GenreViewModel : BaseEntityViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}

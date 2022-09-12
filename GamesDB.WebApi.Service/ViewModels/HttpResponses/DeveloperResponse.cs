using GamesDB.WebApi.Domain.Entities.GamesAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesDB.WebApi.Service.ViewModels.HttpResponses
{
    public class DeveloperResponse
    {
        public DeveloperResponse(Developer developer)
        {
            this.Id = developer.Id;
            this.Name = developer.Name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

    }
}

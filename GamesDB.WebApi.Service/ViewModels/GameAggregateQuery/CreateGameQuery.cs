using GamesDB.WebApi.Domain.Entities.GameAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesDB.WebApi.Service.ViewModels.GameAggregateQuery
{
   public class CreateGameQuery
    {
        public CreateGameQuery()
        {
            this.GenresIds = new List<int>();
        }
        public string Title { get; set; }
        public int? DeveloperId { get; set; }
        public List<int> GenresIds { get; set; }
    }
}

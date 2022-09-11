using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesDB.WebApi.Service.ViewModels.HttpQuerys
{
    public class UpdateGameQuery
    {
        public UpdateGameQuery()
        {
            this.GenresIds = new List<int>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public int? DeveloperId { get; set; }
        public List<int> GenresIds { get; set; }
    }
}

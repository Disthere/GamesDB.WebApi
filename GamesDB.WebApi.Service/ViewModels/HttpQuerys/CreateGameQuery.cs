using System.Collections.Generic;


namespace GamesDB.WebApi.Service.ViewModels.HttpQuerys
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

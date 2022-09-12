using System.Collections.Generic;


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

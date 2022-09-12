using GamesDB.WebApi.Domain.Entities.GamesAggregate;


namespace GamesDB.WebApi.Service.ViewModels.HttpResponses
{
    public class GenreResponse
    {
        public GenreResponse(Genre genre)
        {
            this.Id = genre.Id;
            this.Name = genre.Name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

    }
}

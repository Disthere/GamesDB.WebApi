using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GamesDB.WebApi.Service.ViewModels.HttpQuerys
{
    public class UpdateGameQuery
    {
        public UpdateGameQuery()
        {
            this.GenresIds = new List<int>();
        }


        [RegularExpression(@"\d*", ErrorMessage = "Некорректный id")]
        [Required(ErrorMessage = "Требуется id")]
        public int Id { get; set; }


        [StringLength(maximumLength: 50, MinimumLength = 2,
            ErrorMessage = "Длина имени должна быть от 2 до 50 символов")]
        [Required(ErrorMessage = "Требуется имя")]
        public string Title { get; set; }


        [RegularExpression(@"\d*", ErrorMessage = "Некорректный id разработчика")]
        public int? DeveloperId { get; set; }


        [Required]
        public List<int> GenresIds { get; set; }
    }
}

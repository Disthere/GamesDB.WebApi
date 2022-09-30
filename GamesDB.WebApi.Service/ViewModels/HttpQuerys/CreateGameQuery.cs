using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GamesDB.WebApi.Service.ViewModels.HttpQuerys
{
   public class CreateGameQuery
    {
        public CreateGameQuery()
        {
            this.GenresIds = new List<int>();
        }

        [StringLength(maximumLength: 50, MinimumLength = 2,
            ErrorMessage = "Длина имени должна быть от 2 до 50 символов")]
        [Required(ErrorMessage = "Требуется имя")]
        public string Title { get; set; }

        [RegularExpression(@"\d*", ErrorMessage = "Некорректный id разработчика")]
        public int? DeveloperId { get; set; }

        [Required]
        //[RegularExpression(@"[\[]\s*([0-9]+)+([,][0-9]+)*\s*[\]]", ErrorMessage = "Некорректный набор id жанров, должно быть - 1,3,12,n")]
        public List<int> GenresIds { get; set; }
    }
}

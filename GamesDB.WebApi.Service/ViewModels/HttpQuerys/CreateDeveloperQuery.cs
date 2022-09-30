

using System.ComponentModel.DataAnnotations;

namespace GamesDB.WebApi.Service.ViewModels.HttpQuerys
{
    public class CreateDeveloperQuery
    {
        [StringLength(maximumLength: 50, MinimumLength = 2,
            ErrorMessage = "Длина имени должна быть от 2 до 50 символов")]
        [Required(ErrorMessage = "Требуется имя")]
        public string Name { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freemer.Domain.Enums
{
    /// <summary>
    /// Статусы публикации и выполнения
    /// </summary>
    public enum OrderRelevance
    {
        [Display(Name = "Не опубликовано")]
        NotPublished = 0,

        [Display(Name = "Опубликовано")]
        Published = 1,

        [Display(Name = "Определен исполнитель")]
        WorkerIsSelected = 2,

        [Display(Name = "Выполнено")]
        Completed = 3,

        [Display(Name = "Снято с публикации заказчиком")]
        RemovedByEmployer = 4,

        [Display(Name = "Снято с публикации модератором")]
        RemovedByModerator = 5
    }
}

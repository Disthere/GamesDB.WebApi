using Freemer.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freemer.Domain.Response
{
    // Дженерик - для простой передачи объекта в представление в дальнейшем
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public string Description { get; set; }
        public RequestToDbErrorStatusCode StatusCode { get; set; }
        public T Data { get; set; }
    }

    public interface IBaseResponse<T>
    {
        public string Description { get; set; }
        public RequestToDbErrorStatusCode StatusCode { get; set; }
        T Data { get; }

    }
}

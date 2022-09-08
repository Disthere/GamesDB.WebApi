using GamesDB.WebApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesDB.WebApi.Domain.Response
{
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

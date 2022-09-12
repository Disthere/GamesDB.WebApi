using GamesDB.WebApi.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesDB.WebApi.Domain.DbResponse
{
        public class BaseDbResponse<T> : IBaseDbResponse<T>
    {
        public string Description { get; set; }
        public RequestToDbErrorStatusCode StatusCode { get; set; }
        public T Data { get; set; }
    }

    public interface IBaseDbResponse<T>
    {
        public string Description { get; set; }
        public RequestToDbErrorStatusCode StatusCode { get; set; }
        T Data { get; }
    }
}

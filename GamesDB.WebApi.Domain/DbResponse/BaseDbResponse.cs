using GamesDB.WebApi.Domain.Enums;

namespace GamesDB.WebApi.Domain.DbResponse
{
    public interface IBaseDbResponse<T>
    {
        public string Description { get; set; }
        public RequestToDbErrorStatusCode StatusCode { get; set; }
        public T Data { get; }
    }
    
    public class BaseDbResponse<T> : IBaseDbResponse<T>
    {
        public string Description { get; set; }
        public RequestToDbErrorStatusCode StatusCode { get; set; }
        public T Data { get; set; }
    }
 
}

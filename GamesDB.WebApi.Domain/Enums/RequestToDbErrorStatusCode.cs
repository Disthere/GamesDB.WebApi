using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesDB.WebApi.Domain.Enums
{
    public enum RequestToDbErrorStatusCode
    {
        NotFound = 0,
        Success = 1,
        InternalServerError = 2
    }
}

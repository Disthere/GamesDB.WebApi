using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesDB.WebApi.Controllers
{
    [ApiController]
    [Route("api[controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesDB.WebApi.DAL.MediatR.GamesAggregate.Developers.Queries.GetDeveloperList
{
    public class GetDeveloperListQuery : IRequest<DeveloperListVm>
    {
    }
}

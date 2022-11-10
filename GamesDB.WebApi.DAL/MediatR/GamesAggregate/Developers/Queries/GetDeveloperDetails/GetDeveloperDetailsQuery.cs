using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesDB.WebApi.DAL.MediatR.GamesAggregate.Developers.Queries.GetDeveloperDetails
{
    public class GetDeveloperDetailsQuery : IRequest<DeveloperDetailsVm>
    {
        public int Id { get; set; }
    }
}

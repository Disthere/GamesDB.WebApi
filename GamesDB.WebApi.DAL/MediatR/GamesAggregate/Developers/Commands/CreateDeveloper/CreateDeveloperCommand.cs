using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesDB.WebApi.DAL.MediatR.GamesAggregate.Developers.Commands.CreateDeveloper
{
    public class CreateDeveloperCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}

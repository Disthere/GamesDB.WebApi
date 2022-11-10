using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesDB.WebApi.DAL.MediatR.GamesAggregate.Developers.Commands.UpdateDeveloper
{
    public class UpdateDeveloperCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

using GamesDB.WebApi.DAL.Interfaces;
using GamesDB.WebApi.Domain.Entities.GamesAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GamesDB.WebApi.DAL.MediatR.GamesAggregate.Developers.Commands.CreateDeveloper
{
    public class CreateDeveloperCommandHandler : IRequestHandler<CreateDeveloperCommand, int>
    {
        private readonly IGamesDbContext _gamesDbContext;

        public CreateDeveloperCommandHandler(IGamesDbContext gamesDbContext) =>
            _gamesDbContext = gamesDbContext;


        public async Task<int> Handle(CreateDeveloperCommand request, CancellationToken cancellationToken)
        {
            var developer = new Developer()
            {
                Name = request.Name
            };

            await _gamesDbContext.Developers.AddAsync(developer, cancellationToken);
            await _gamesDbContext.SaveChangesAsync(cancellationToken);

            return developer.Id;
        }
    }
}

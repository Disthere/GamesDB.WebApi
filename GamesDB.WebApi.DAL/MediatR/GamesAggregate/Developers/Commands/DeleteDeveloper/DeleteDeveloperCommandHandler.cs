using GamesDB.WebApi.DAL.Common.Exceptions;
using GamesDB.WebApi.DAL.Interfaces;
using GamesDB.WebApi.Domain.Entities.GamesAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GamesDB.WebApi.DAL.MediatR.GamesAggregate.Developers.Commands.DeleteDeveloper
{
    public class DeleteDeveloperCommandHandler : IRequestHandler<DeleteDeveloperCommand>
    {
        private readonly IGamesDbContext _gamesDbContext;

        public DeleteDeveloperCommandHandler(IGamesDbContext gamesDbContext) =>
            _gamesDbContext = gamesDbContext;


        public async Task<Unit> Handle(DeleteDeveloperCommand request, CancellationToken cancellationToken)
        {
            var entity = await _gamesDbContext.Developers
                .FindAsync(new object[] { request.Id }, cancellationToken);
             
            if(entity == null)
                throw new NotFoundException(nameof(Developer), request.Id);

            _gamesDbContext.Developers.Remove(entity);
            await _gamesDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

using GamesDB.WebApi.DAL.Common.Exceptions;
using GamesDB.WebApi.DAL.Interfaces;
using GamesDB.WebApi.Domain.Entities.GamesAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GamesDB.WebApi.DAL.MediatR.GamesAggregate.Developers.Commands.UpdateDeveloper
{
    public class UpdateDeveloperCommandHandler : IRequestHandler<UpdateDeveloperCommand>
    {
        private readonly IGamesDbContext _gamesDbContext;

        public UpdateDeveloperCommandHandler(IGamesDbContext gamesDbContext) => 
            _gamesDbContext = gamesDbContext;

        public async Task<Unit> Handle(UpdateDeveloperCommand request, CancellationToken cancellationToken)
        {
           var entity = await _gamesDbContext.Developers.FirstOrDefaultAsync(
               d=>d.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Developer), request.Id);

            entity.Name = request.Name;

            await _gamesDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

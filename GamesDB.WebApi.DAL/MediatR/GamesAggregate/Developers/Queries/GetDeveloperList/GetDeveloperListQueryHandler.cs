using AutoMapper;
using AutoMapper.QueryableExtensions;
using GamesDB.WebApi.DAL.Common.Exceptions;
using GamesDB.WebApi.DAL.Interfaces;
using GamesDB.WebApi.DAL.MediatR.GamesAggregate.Developers.Queries.GetDeveloperDetails;
using GamesDB.WebApi.Domain.Entities.GamesAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GamesDB.WebApi.DAL.MediatR.GamesAggregate.Developers.Queries.GetDeveloperList
{
    public class GetDeveloperListQueryHandler
        : IRequestHandler<GetDeveloperListQuery, DeveloperListVm>
    {
        private readonly IGamesDbContext _gamesDbContext;
        private readonly IMapper _mapper;

        public GetDeveloperListQueryHandler(IGamesDbContext gamesDbContext, IMapper mapper) =>
            (_gamesDbContext, _mapper) = (gamesDbContext, mapper);


        public async Task<DeveloperDetailsVm> Handle(GetDeveloperDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _gamesDbContext.Developers
                .FirstOrDefaultAsync(developer =>
                developer.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Developer), request.Id);

            return _mapper.Map<DeveloperDetailsVm>(entity);
        }

        public async Task<DeveloperListVm> Handle(GetDeveloperListQuery request, CancellationToken cancellationToken)
        {
            var developersQuery = await _gamesDbContext.Developers
                 .ProjectTo<DeveloperLookupDto>(_mapper.ConfigurationProvider)
                 .ToListAsync(cancellationToken);

            return new DeveloperListVm { Developers = developersQuery };
        }
    }
}

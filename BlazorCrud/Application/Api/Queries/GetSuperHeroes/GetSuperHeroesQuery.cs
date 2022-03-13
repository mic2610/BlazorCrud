using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Api.Queries.GetSuperHeroes
{
    public class GetSuperHeroesQuery : IRequest<SuperHeroesDto>
    {
    }

    public class GetSuperHeroesQueryHandler : IRequestHandler<GetSuperHeroesQuery, SuperHeroesDto>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetSuperHeroesQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<SuperHeroesDto> Handle(GetSuperHeroesQuery request, CancellationToken cancellationToken)
        {
            return new SuperHeroesDto { SuperHeroes = await _applicationDbContext.SuperHeroes.ToListAsync(cancellationToken) };
        }
    }
}
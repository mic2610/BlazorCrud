using Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
            return new SuperHeroesDto { SuperHeroes = await _applicationDbContext.SuperHeroes.Include(s => s.Comic).ToListAsync(cancellationToken) };
        }
    }
}
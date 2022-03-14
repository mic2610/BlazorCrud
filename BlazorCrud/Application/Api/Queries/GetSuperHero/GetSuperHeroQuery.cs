using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Api.Queries.GetSuperHeroes
{
    public class GetSuperHeroQuery : IRequest<SuperHeroDto>
    {
        public int Id { get; set; }
    }

    public class GetSuperHeroQueryHandler : IRequestHandler<GetSuperHeroQuery, SuperHeroDto>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public GetSuperHeroQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<SuperHeroDto> Handle(GetSuperHeroQuery request, CancellationToken cancellationToken)
        {
            return new SuperHeroDto { SuperHero = await _applicationDbContext.SuperHeroes.FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken) };
        }
    }
}

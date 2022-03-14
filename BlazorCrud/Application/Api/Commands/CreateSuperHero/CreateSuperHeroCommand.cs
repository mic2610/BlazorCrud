using Application.Api.Queries.GetComics;
using Application.Api.Queries.GetSuperHeroes;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Api.Commands.CreateSuperHero
{
    public class CreateSuperHeroCommand : IRequest<SuperHeroesDto>
    {
        public SuperHero SuperHero { get; set; }
    }

    public class CreateSuperHeroCommandHandler : IRequestHandler<CreateSuperHeroCommand, SuperHeroesDto>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public CreateSuperHeroCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<SuperHeroesDto> Handle(CreateSuperHeroCommand request, CancellationToken cancellationToken)
        {
            request.SuperHero.Comic = null;
            _applicationDbContext.SuperHeroes.Add(request.SuperHero);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return new SuperHeroesDto { SuperHeroes = await _applicationDbContext.SuperHeroes.Include(s => s.Comic).ToListAsync(cancellationToken) };
        }
    }
}
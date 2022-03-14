using Application.Api.Queries.GetComics;
using Application.Api.Queries.GetSuperHeroes;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Api.Commands.DeleteSuperHero
{
    public class DeleteSuperHeroCommand : IRequest<SuperHeroesDto>
    {
        public int Id { get; set; }
    }

    public class DeleteSuperHeroCommandHandler : IRequestHandler<DeleteSuperHeroCommand, SuperHeroesDto>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public DeleteSuperHeroCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<SuperHeroesDto> Handle(DeleteSuperHeroCommand request, CancellationToken cancellationToken)
        {
            var superHero = await _applicationDbContext.SuperHeroes.Include(s => s.Comic).FirstOrDefaultAsync(s => s.Id == request.Id);
            if (superHero == null)
                return null;

            _applicationDbContext.SuperHeroes.Remove(superHero);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return new SuperHeroesDto { SuperHeroes = await _applicationDbContext.SuperHeroes.Include(s => s.Comic).ToListAsync(cancellationToken) };
        }
    }
}
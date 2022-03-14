using Application.Api.Queries.GetComics;
using Application.Api.Queries.GetSuperHeroes;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Api.Commands.UpdateSuperHro
{
    public class UpdateSuperHeroCommand : IRequest<SuperHeroesDto>
    {
        public SuperHero SuperHero { get; set; }

        public int Id { get; set; }
    }

    public class UpdateSuperHeroCommandHandler : IRequestHandler<UpdateSuperHeroCommand, SuperHeroesDto>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public UpdateSuperHeroCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<SuperHeroesDto> Handle(UpdateSuperHeroCommand request, CancellationToken cancellationToken)
        {
            var dbHero = await _applicationDbContext.SuperHeroes
                .Include(sh => sh.Comic)
                .FirstOrDefaultAsync(sh => sh.Id == request.Id);
            if (dbHero == null)
                return null;

            dbHero.FirstName = request.SuperHero.FirstName;
            dbHero.LastName = request.SuperHero.LastName;
            dbHero.HeroName = request.SuperHero.HeroName;
            dbHero.ComicId = request.SuperHero.ComicId;

            _applicationDbContext.SuperHeroes.Update(dbHero);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return new SuperHeroesDto { SuperHeroes = await _applicationDbContext.SuperHeroes.Include(s => s.Comic).ToListAsync(cancellationToken) };
        }
    }
}
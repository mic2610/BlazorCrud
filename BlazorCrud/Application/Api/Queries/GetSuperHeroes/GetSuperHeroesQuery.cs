using Domain.Entities;
using MediatR;
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
        public async Task<SuperHeroesDto> Handle(GetSuperHeroesQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            return new SuperHeroesDto { SuperHeroes = new List<SuperHero> { new SuperHero { Id = 1, FirstName = "Bat", LastName = "Man", HeroName = "Dark Knight" } } };
        }
    }
}

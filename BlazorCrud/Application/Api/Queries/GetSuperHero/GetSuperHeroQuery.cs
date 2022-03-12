using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Api.Queries.GetSuperHeroes
{
    public class GetSuperHeroQuery : IRequest<SuperHeroDto>
    {
        public int Id { get; set; }
    }

    public class GetSuperHeroQueryHandler : IRequestHandler<GetSuperHeroQuery, SuperHeroDto>
    {
        public async Task<SuperHeroDto> Handle(GetSuperHeroQuery request, CancellationToken cancellationToken)
        {
            var superHeroes = new List<SuperHero> { new SuperHero { Id = 1, FirstName = "Bat", LastName = "Man", HeroName = "Dark Knight" } };
            await Task.CompletedTask;
            return new SuperHeroDto { SuperHero = superHeroes?.FirstOrDefault(s => s.Id == request.Id) };
        }
    }
}

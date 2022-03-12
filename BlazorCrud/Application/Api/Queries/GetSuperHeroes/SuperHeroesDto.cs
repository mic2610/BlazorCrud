using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Api.Queries.GetSuperHeroes
{
    public class SuperHeroesDto
    {
        public IList<SuperHero>? SuperHeroes { get; set; }
    }
}

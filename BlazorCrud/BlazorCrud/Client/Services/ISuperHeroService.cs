using Application.Api.Queries.GetSuperHeroes;
using Domain.Entities;

namespace BlazorCrud.Client.Services
{
    public interface ISuperHeroService
    {
        List<Comic> Comics { get; set; }
        SuperHeroesDto? SuperHeroes { get; set; }

        Task CreateHero(SuperHeroDto hero);
        Task DeleteHero(int id);
        Task GetComics();
        Task<SuperHeroDto> GetSingleHero(int id);
        Task GetSuperHeroes();
        Task UpdateHero(SuperHero hero);
    }
}
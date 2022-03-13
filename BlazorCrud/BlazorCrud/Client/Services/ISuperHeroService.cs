using Application.Api.Queries.GetComics;
using Application.Api.Queries.GetSuperHeroes;
using Domain.Entities;

namespace BlazorCrud.Client.Services
{
    public interface ISuperHeroService
    {
        ComicsDto Comics { get; set; }
        SuperHeroesDto SuperHeroes { get; set; }

        Task CreateHero(SuperHeroDto hero);
        Task DeleteHero(int id);
        Task GetComics();
        Task<SuperHeroDto> GetSingleHero(int id);
        Task GetSetSuperHeroes();
        Task UpdateHero(SuperHero hero);
    }
}
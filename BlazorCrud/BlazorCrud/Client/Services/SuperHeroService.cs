using Application.Api.Queries.GetSuperHeroes;
using Domain.Entities;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorCrud.Client.Services
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public SuperHeroService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public SuperHeroesDto? SuperHeroes { get; set; } = new SuperHeroesDto();
        public List<Comic> Comics { get; set; } = new List<Comic>();

        public async Task CreateHero(SuperHeroDto hero)
        {
            var result = await _http.PostAsJsonAsync("api/superhero", hero);
            await SetHeroes(result);
        }

        private async Task SetHeroes(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<SuperHeroesDto>();
            SuperHeroes = response;
            _navigationManager.NavigateTo("superheroes");
        }

        public async Task DeleteHero(int id)
        {
            var result = await _http.DeleteAsync($"api/superhero/{id}");
            await SetHeroes(result);
        }

        public async Task GetComics()
        {
            var result = await _http.GetFromJsonAsync<List<Comic>>("api/superhero/comics");
            if (result != null)
                Comics = result;
        }

        public async Task<SuperHeroDto> GetSingleHero(int id)
        {
            var result = await _http.GetFromJsonAsync<SuperHeroDto>($"api/superhero/{id}");
            if (result != null)
                return result;
            throw new Exception("Hero not found!");
        }

        public async Task GetSuperHeroes()
        {
            var result = await _http.GetFromJsonAsync<SuperHeroesDto>("api/superhero");
            if (result != null)
                SuperHeroes = result;
        }

        public async Task UpdateHero(SuperHero hero)
        {
            var result = await _http.PutAsJsonAsync($"api/superhero/{hero.Id}", hero);
            await SetHeroes(result);
        }
    }
}

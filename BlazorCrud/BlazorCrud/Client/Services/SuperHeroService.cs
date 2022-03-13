using Application.Api.Queries.GetComics;
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

        public SuperHeroesDto SuperHeroes { get; set; } = new SuperHeroesDto { SuperHeroes = new List<SuperHero>() };
        public ComicsDto Comics { get; set; } = new ComicsDto { Comics = new List<Comic>() };

        public string Error = string.Empty;

        public async Task CreateHero(SuperHeroDto hero)
        {
            var result = await _http.PostAsJsonAsync("api/superhero/superheroes", hero);
            await SetHeroes(result);
        }

        public async Task DeleteHero(int id)
        {
            var result = await _http.DeleteAsync($"api/superhero/{id}");
            await SetHeroes(result);
        }

        public async Task GetComics()
        {
            try
            {
                var result = await _http.GetFromJsonAsync<ComicsDto>("api/superhero/allcomics");
                if (result != null)
                    Comics = result;
            }
            catch (Exception ex)
            {
                var error = ex.ToString();
                Error = error;
            }
        }

        public async Task<SuperHeroDto> GetSingleHero(int id)
        {
            var result = await _http.GetFromJsonAsync<SuperHeroDto>($"api/superhero/{id}");
            if (result != null)
                return result;
            throw new Exception("Hero not found!");
        }

        public async Task GetSetSuperHeroes()
        {
            var result = await _http.GetFromJsonAsync<SuperHeroesDto>("api/superhero/superheroes");
            if (result != null)
                SuperHeroes = result;
        }

        public async Task UpdateHero(SuperHero hero)
        {
            var result = await _http.PutAsJsonAsync($"api/superhero/{hero.Id}", hero);
            await SetHeroes(result);
        }

        private async Task SetHeroes(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<SuperHeroesDto>();
            SuperHeroes = response;
            _navigationManager.NavigateTo("superheroes");
        }
    }
}

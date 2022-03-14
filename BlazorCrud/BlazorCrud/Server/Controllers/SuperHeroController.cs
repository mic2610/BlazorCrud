using Application.Api.Commands.CreateSuperHero;
using Application.Api.Commands.DeleteSuperHero;
using Application.Api.Commands.UpdateSuperHro;
using Application.Api.Queries.GetComics;
using Application.Api.Queries.GetSuperHeroes;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCrud.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SuperHeroController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SuperHeroDto>> GetSuperHero(int id)
        {
            return await _mediator.Send(new GetSuperHeroQuery { Id = id });
        }

        [HttpGet]
        [Route("superheroes")]
        public async Task<ActionResult<SuperHeroesDto>> GetSuperHeroes()
        {
            return await _mediator.Send(new GetSuperHeroesQuery());
        }

        // WARNING: If an API endpoint does not work, you have to change the route, it's buggy as hell
        //[HttpGet]
        //[Route("comics")]
        //public async Task<ActionResult<ComicsDto>> GetComics()
        //{
        //    return await _mediator.Send(new GetComicsQuery());
        //}

        [HttpGet]
        [Route("allcomics")]
        public async Task<ActionResult<ComicsDto>> GetComics()
        {
            return await _mediator.Send(new GetComicsQuery());
        }

        [HttpPost]
        public async Task<ActionResult<SuperHeroesDto>> CreateSuperHero(SuperHeroDto hero)
        {
            return await _mediator.Send(new CreateSuperHeroCommand { SuperHero = hero?.SuperHero });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SuperHeroesDto>> UpdateSuperHero(SuperHeroDto hero, int id)
        {
            return await _mediator.Send(new UpdateSuperHeroCommand { SuperHero = hero?.SuperHero, Id = id });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SuperHeroesDto>> DeleteSuperHero(int id)
        {
            return await _mediator.Send(new DeleteSuperHeroCommand { Id = id });
        }
    }
}

using Application.Api.Queries.GetSuperHeroes;
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

        [HttpGet]
        public async Task<ActionResult<SuperHeroesDto>> GetSuperHeroes()
        {
            return await _mediator.Send(new GetSuperHeroesQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHeroDto>> GetSuperHero(int id)
        {
            return await _mediator.Send(new GetSuperHeroQuery { Id = id });
        }
    }
}

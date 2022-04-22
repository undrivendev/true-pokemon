using Microsoft.AspNetCore.Mvc;
using TruePokemon.Application.Queries;
using TruePokemon.Core.Mediator;
using TruePokemon.Core.Models;

namespace TruePokemon.Api.Controllers;

public class PokemonController : AppControllerBase
{
    public PokemonController(IMediator mediator)
        : base(mediator)
    {
    }

    [HttpGet]
    [Route("{name}")]
    public async Task<ActionResult<PokemonTranslation>> Get(string name) =>
        await _mediator.SendQuery<GetPokemonTranslationByNameQuery, PokemonTranslation>(
            new GetPokemonTranslationByNameQuery(name));
}
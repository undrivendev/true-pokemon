using Microsoft.AspNetCore.Mvc;
using TruePokemon.Api.Customers.Requests;
using TruePokemon.Api.Customers.Responses;
using TruePokemon.Application.Customers.Commands;
using TruePokemon.Application.Customers.Queries;
using TruePokemon.Core;
using TruePokemon.Core.Customers;
using TruePokemon.Core.Mediator;

namespace TruePokemon.Api.Pokemon;

public class PokemonController : AppControllerBase
{
    public PokemonController(IMediator mediator)
        : base(mediator)
    {
    }

    [HttpGet]
    [Route("{name}")]
    public async Task<ActionResult<PokemonTranslationResponse>> Create(string name)
    {
        var id = await _mediator.SendCommand<CreateCustomerCommand, int>(
            new CreateCustomerCommand(request.ToDomainEntity()));
        return CreatedAtAction(nameof(Get), new { id }, new PokemonTranslationResponse(id));
    }
}
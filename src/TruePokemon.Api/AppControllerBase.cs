using Microsoft.AspNetCore.Mvc;
using TruePokemon.Core.Mediator;

namespace TruePokemon.Api;

[ApiController]
[Route("api/[controller]")]
public abstract class AppControllerBase : ControllerBase
{
    protected readonly IMediator _mediator;

    public AppControllerBase(IMediator mediator)
    {
        _mediator = mediator;
    }
}
using Microsoft.AspNetCore.Mvc;
using TruePokemon.Api.Customers.Requests;
using TruePokemon.Api.Customers.Responses;
using TruePokemon.Application.Customers.Commands;
using TruePokemon.Application.Customers.Queries;
using TruePokemon.Core;
using TruePokemon.Core.Customers;
using TruePokemon.Core.Mediator;

namespace TruePokemon.Api.Customers;

public class CustomersController : AppControllerBase
{
    public CustomersController(IMediator mediator)
        : base(mediator)
    {
    }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult<CustomerCreatedResponse>> Create(CreateCustomerRequest request)
    {
        var id = await _mediator.SendCommand<CreateCustomerCommand, int>(
            new CreateCustomerCommand(request.ToDomainEntity()));
        return CreatedAtAction(nameof(Get), new { id }, new CustomerCreatedResponse(id));
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Customer>> Get(int id)
        => Ok(await _mediator.SendQuery<GetCustomerByIdQuery, Customer>(new GetCustomerByIdQuery(id)));

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateCustomerRequest request)
    {
        await _mediator.SendCommand<UpdateCustomerCommand, Nothing>(
            new UpdateCustomerCommand(id, request.ToDomainEntity()));
        return NoContent();
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.SendCommand<DeleteCustomerCommand, Nothing>(new DeleteCustomerCommand(id));
        return NoContent();
    }
}
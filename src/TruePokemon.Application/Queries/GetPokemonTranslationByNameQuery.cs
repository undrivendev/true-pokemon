using TruePokemon.Core.Customers;
using TruePokemon.Core.Mediator;

namespace TruePokemon.Application.Queries;

public record GetCustomerByIdQuery(int Id) : IQuery<Customer>;
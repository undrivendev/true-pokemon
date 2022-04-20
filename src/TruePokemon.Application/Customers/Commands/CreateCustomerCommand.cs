using TruePokemon.Core.Customers;
using TruePokemon.Core.Mediator;

namespace TruePokemon.Application.Customers.Commands;

public record CreateCustomerCommand(Customer Customer) : ICommand<int>;
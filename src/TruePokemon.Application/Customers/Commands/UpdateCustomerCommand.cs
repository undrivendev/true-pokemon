using TruePokemon.Core;
using TruePokemon.Core.Customers;
using TruePokemon.Core.Mediator;

namespace TruePokemon.Application.Customers.Commands;

public record UpdateCustomerCommand(int Id, Customer Customer) : ICommand<Nothing>;
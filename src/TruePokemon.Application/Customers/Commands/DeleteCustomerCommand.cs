using TruePokemon.Core;
using TruePokemon.Core.Mediator;

namespace TruePokemon.Application.Customers.Commands;

public record DeleteCustomerCommand(int Id) : ICommand<Nothing>;
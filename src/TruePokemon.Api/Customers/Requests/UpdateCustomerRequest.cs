using TruePokemon.Core.Customers;

namespace TruePokemon.Api.Customers.Requests;

public class UpdateCustomerRequest
{
    public Customer ToDomainEntity() => new(null);
}
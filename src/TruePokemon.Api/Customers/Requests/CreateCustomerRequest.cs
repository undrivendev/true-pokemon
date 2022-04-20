using TruePokemon.Core.Customers;

namespace TruePokemon.Api.Customers.Requests;

public class CreateCustomerRequest
{
    
    public Customer ToDomainEntity() => new(null);
}
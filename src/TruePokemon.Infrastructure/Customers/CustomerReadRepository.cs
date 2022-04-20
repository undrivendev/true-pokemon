using Microsoft.Extensions.Options;
using TruePokemon.Core.Customers;
using TruePokemon.Infrastructure.Persistence;

namespace TruePokemon.Infrastructure.Customers;

public class CustomerReadRepository : ReadRepositoryBase<Customer>, ICustomerReadRepository
{
    public CustomerReadRepository(IOptionsMonitor<ReadRepositoryOptions> options)
        : base(options)
    {
    }
}
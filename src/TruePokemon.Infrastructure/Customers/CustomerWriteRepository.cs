using TruePokemon.Core;
using TruePokemon.Core.Customers;
using TruePokemon.Infrastructure.Persistence;

namespace TruePokemon.Infrastructure.Customers;

public class CustomerWriteRepository : WriteRepositoryBase<Customer>, ICustomerWriteRepository
{
    public CustomerWriteRepository() : base()
    {
    }
}
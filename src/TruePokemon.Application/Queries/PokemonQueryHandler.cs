using TruePokemon.Application.Customers.Queries;
using TruePokemon.Core.Customers;
using TruePokemon.Core.Mediator;

namespace TruePokemon.Application.Customers;

public class CustomerQueryHandler : IQueryHandler<GetCustomerByIdQuery, Customer>
{
    private readonly ICustomerReadRepository _customerReadRepository;

    public CustomerQueryHandler(ICustomerReadRepository customerReadRepository)
    {
        _customerReadRepository = customerReadRepository;
    }

    public Task<Customer> Handle(GetCustomerByIdQuery query, CancellationToken cancellationToken = default)
        => _customerReadRepository.GetById(query.Id);
}
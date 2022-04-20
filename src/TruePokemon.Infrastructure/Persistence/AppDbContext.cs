using Microsoft.EntityFrameworkCore;
using TruePokemon.Core.Customers;

namespace TruePokemon.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<Customer> Customers => Set<Customer>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
}
using TruePokemon.Core.Customers;
using TruePokemon.Infrastructure.Persistence;

namespace TruePokemon.IntegrationTests;

public static class Utils
{
    public static void SeedTestData(AppDbContext context)
    {
        context.Customers.Add(new Customer(1));
        context.SaveChanges();
    }
}
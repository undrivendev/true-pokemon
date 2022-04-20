using Microsoft.EntityFrameworkCore;
using TruePokemon.Core;

namespace TruePokemon.Infrastructure.Persistence;

public class UnitOfWorkFactory : IUnitOfWorkFactory
{
    private readonly IDbContextFactory<AppDbContext> _dbContextFactory;

    public UnitOfWorkFactory(IDbContextFactory<AppDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task<IUnitOfWork> Create(CancellationToken cancellationToken = default)
    {
        var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        return new UnitOfWork(dbContext);
    }
}
namespace TruePokemon.Core;

public interface IUnitOfWorkFactory
{
    Task<IUnitOfWork> Create(CancellationToken cancellationToken = default);
}
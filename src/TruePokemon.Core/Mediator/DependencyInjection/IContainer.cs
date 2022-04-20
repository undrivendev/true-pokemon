namespace TruePokemon.Core.Mediator.DependencyInjection;

public interface IContainer
{
    public TService Resolve<TService>() where TService : notnull;
}
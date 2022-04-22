namespace TruePokemon.Core.Abstractions;

public interface IPokemonDataRepository
{
    public Task<string?> GetSpeciesDescription(string pokemonName, CancellationToken cancellationToken = default);
}
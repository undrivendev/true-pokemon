using TruePokemon.Core.Abstractions;
using TruePokemon.Core.Mediator;
using TruePokemon.Core.Models;

namespace TruePokemon.Application.Queries;

public class PokemonQueryHandler : IQueryHandler<GetPokemonTranslationByNameQuery, PokemonTranslation>
{
    private readonly IPokemonDataRepository _pokemonDataRepository;
    private readonly ITranslationRepository _translationRepository;

    public PokemonQueryHandler(IPokemonDataRepository pokemonDataRepository, ITranslationRepository translationRepository)
    {
        _pokemonDataRepository = pokemonDataRepository;
        _translationRepository = translationRepository;
    }

    public async Task<PokemonTranslation> Handle(
        GetPokemonTranslationByNameQuery query,
        CancellationToken cancellationToken = default)
    {
        string? translation = null;
        try
        {
            var description = await _pokemonDataRepository.GetSpeciesDescription(query.Name, cancellationToken);
            if (!string.IsNullOrWhiteSpace(description))
            {
                translation = await _translationRepository.Translate(description, cancellationToken);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            // don't throw, return fallback value
        }

        return new PokemonTranslation(query.Name, translation ?? Constants.FallbackTranslation);
    }
}
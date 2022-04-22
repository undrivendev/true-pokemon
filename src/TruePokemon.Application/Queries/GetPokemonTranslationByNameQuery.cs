using TruePokemon.Core.Mediator;
using TruePokemon.Core.Models;

namespace TruePokemon.Application.Queries;

public record GetPokemonTranslationByNameQuery(string Name) : IQuery<PokemonTranslation>;
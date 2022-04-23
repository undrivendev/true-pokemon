using System.Net.Http.Json;
using System.Text.Json.Nodes;
using Microsoft.Extensions.Options;
using TruePokemon.Core.Abstractions;

namespace TruePokemon.Infrastructure;

public class PokemonDataApiRepository : BaseApi, IPokemonDataRepository
{
    public PokemonDataApiRepository(
        IHttpClientFactory httpClientFactory,
        PokemonDataApiRepositoryOptions options) : base(httpClientFactory, options)
    {
    }

    public async Task<string?> GetSpeciesDescription(string pokemonName, CancellationToken cancellationToken = default)
    {
        var client = GetHttpClient(nameof(PokemonDataApiRepository));
        var pokemonObj = await client.GetFromJsonAsync<JsonNode>(
            $"pokemon/{pokemonName}",
            cancellationToken);
        var speciesUrl = pokemonObj?["species"]?["url"]?.ToString();
        if (string.IsNullOrWhiteSpace(speciesUrl))
        {
            return null;
        }

        var speciesObj = await client.GetFromJsonAsync<JsonNode>(
            new Uri(speciesUrl),
            cancellationToken);

        var tempDescription = speciesObj?["flavor_text_entries"]?[0]?["flavor_text"]?.ToString();
        return DecodeDescription(tempDescription);
    }

    private static string? DecodeDescription(string? input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return null;
        }

        return input.Replace('\n', ' ').Replace('\f', ' ');
    }
}
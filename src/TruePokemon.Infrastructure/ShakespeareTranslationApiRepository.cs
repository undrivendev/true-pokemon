using System.Net.Http.Json;
using System.Text.Json.Nodes;
using System.Web;
using Microsoft.Extensions.Options;
using TruePokemon.Core.Abstractions;

namespace TruePokemon.Infrastructure;

public class ShakespeareTranslationApiRepository : BaseApi, ITranslationRepository
{
    public ShakespeareTranslationApiRepository(
        IHttpClientFactory httpClientFactory,
        ShakespeareTranslationApiRepositoryOptions options)
        : base(httpClientFactory, options)
    {
    }

    public async Task<string?> Translate(string input, CancellationToken cancellationToken = default)
    {
        var client = GetHttpClient(nameof(ShakespeareTranslationApiRepository));
        var resultObj = await client.GetFromJsonAsync<JsonNode>(
            $"shakespeare.json?text={HttpUtility.JavaScriptStringEncode(input)}",
            cancellationToken);
        return resultObj?["contents"]?["translated"]?.ToString();
    }
}
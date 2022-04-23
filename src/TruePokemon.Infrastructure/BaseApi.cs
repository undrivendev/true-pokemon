using System.Net;
using Microsoft.Extensions.Options;

namespace TruePokemon.Infrastructure;

public abstract class BaseApi
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly BaseApiOptions _options;

    protected BaseApi(IHttpClientFactory httpClientFactory, BaseApiOptions options)
    {
        _httpClientFactory = httpClientFactory;
        _options = options;
    }

    protected HttpClient GetHttpClient(string name)
    {
        var client = _httpClientFactory.CreateClient(name);
        client.BaseAddress = _options.BaseUrl;
        client.DefaultRequestVersion = Version.TryParse(_options.HttpVersion, out var parsedVersion)
            ? parsedVersion
            : Constants.DefaultHttpVersion;
        return client;
    }
}
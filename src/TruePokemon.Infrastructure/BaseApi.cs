using System.Net;
using Microsoft.Extensions.Options;

namespace TruePokemon.Infrastructure;

public abstract class BaseApi
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IOptionsMonitor<BaseApiOptions> _optionsMonitor;

    protected BaseApi(IHttpClientFactory httpClientFactory, IOptionsMonitor<BaseApiOptions> optionsMonitor)
    {
        _httpClientFactory = httpClientFactory;
        _optionsMonitor = optionsMonitor;
    }

    protected HttpClient GetHttpClient(string name)
    {
        var client = _httpClientFactory.CreateClient(name);
        client.BaseAddress = _optionsMonitor.CurrentValue.BaseUrl;
        client.DefaultRequestVersion = Version.TryParse(_optionsMonitor.CurrentValue.HttpVersion, out var parsedVersion)
            ? parsedVersion
            : Constants.DefaultHttpVersion;
        return client;
    }
}
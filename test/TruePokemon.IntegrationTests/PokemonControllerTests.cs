using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace TruePokemon.IntegrationTests;

[Trait("Category", "Integration")]
public class CustomersControllerTests : IClassFixture<AppWebApplicationFactory>
{
    readonly HttpClient _client;

    public CustomersControllerTests(AppWebApplicationFactory application)
    {
        _client = application.CreateClient();
    }


    [Fact]
    public async Task GetById_ValidRequest_ReturnsCorrectly()
    {
        
    }
}
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using TruePokemon.Application.Queries;
using TruePokemon.Core.Abstractions;
using TruePokemon.Infrastructure;
using Xunit;

namespace TruePokemon.UnitTests.Infrastructure;

public class PokemonDataApiRepositoryTests
{
    [Fact]
    public async Task GetSpeciesDescription_ValidInput_ReturnsCorrectly()
    {
        // Arrange
        var pokemonName = "ditto";
        var expected = "Expected value";
        var options = new PokemonDataApiRepositoryOptions { BaseUrl = new Uri("http://localhost:5000") };
        var optionsMonitor = new Mock<IOptionsMonitor<PokemonDataApiRepositoryOptions>>();
        optionsMonitor.Setup(x => x.CurrentValue).Returns(options);

        var handler = new MockHttpClientHandler();
        handler.AddMockResponse(new Uri(options.BaseUrl, $"pokemon/{pokemonName}"), HttpStatusCode.OK,
            @"{""species"":{""url"":""https://www.test.com""}}");
        handler.AddMockResponse(new Uri("https://www.test.com"), HttpStatusCode.OK,
            @$"{{""flavor_text_entries"" : [{{""flavor_text"":""{expected}""}}]}}");

        var clientFactory = new Mock<IHttpClientFactory>();
        clientFactory.Setup(x => x.CreateClient(It.IsAny<string>()))
            .Returns(new HttpClient(handler));

        var sut = new PokemonDataApiRepository(clientFactory.Object, optionsMonitor.Object);

        // Act
        var result = await sut.GetSpeciesDescription(pokemonName);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }
}
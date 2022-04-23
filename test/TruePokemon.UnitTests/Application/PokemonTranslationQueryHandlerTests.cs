using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using TruePokemon.Application.Queries;
using TruePokemon.Core.Abstractions;
using Xunit;

namespace TruePokemon.UnitTests;

public class PokemonTranslationQueryHandlerTests
{
    [Fact]
    public async Task Handle_ValidInput_ReturnsCorrectly()
    {
        // Arrange
        var expected = "Sample translation";
        var dataRepo = new Mock<IPokemonDataRepository>();
        dataRepo.Setup(x => x.GetSpeciesDescription(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync("Sample description");
        var translationRepo = new Mock<ITranslationService>();
        translationRepo.Setup(x => x.Translate(
                It.Is<string>(y => y == "Sample description"),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(expected);
        var sut = new PokemonQueryHandler(dataRepo.Object, translationRepo.Object);

        // Act
        var result = await sut.Handle(new GetPokemonTranslationByNameQuery("test"));

        // Assert
        result.Translation.Should().BeEquivalentTo(expected);
    }
}
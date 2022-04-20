using FluentAssertions;
using Moq;
using TruePokemon.Application.Customers;
using TruePokemon.Application.Customers.Queries;
using TruePokemon.Core.Customers;
using Xunit;

namespace TruePokemon.UnitTests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        // Arrange
        var expected = new Customer(1);
        var mock = new Mock<ICustomerReadRepository>();
        mock.Setup(e => e.GetById(It.IsAny<int>())).ReturnsAsync(expected);

        var sut = new CustomerQueryHandler(mock.Object);
        
        // Act
        var result = sut.Handle(new GetCustomerByIdQuery(1));

        // Assert
        result.Should().BeEquivalentTo(expected);
    }
}
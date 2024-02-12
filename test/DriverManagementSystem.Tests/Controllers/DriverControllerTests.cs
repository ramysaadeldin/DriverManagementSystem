using Bogus;
using DriverManagementSystem.API.Controllers;
using DriverManagementSystem.Application.Commands.DriverCommands;
using DriverManagementSystem.Application.Queries.DriverQueries;
using DriverManagementSystem.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;
using Xunit;

namespace DriverManagementSystem.Tests.Controllers;

public class DriverControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly DriverController _driverController;

    public DriverControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _driverController = new DriverController(_mediatorMock.Object);

        //  _driverController.InsertRandomNames().Wait();

    }

    [Fact]
    public async Task InsertRandomNames_ReturnsOkResult()
    {
        // Arrange

        // Act
        var result = await _driverController.InsertRandomNames() as OkObjectResult;

        // Assert
        result.ShouldNotBe(null);
        result.Value.ShouldBeOfType<ApiResponse<object>>();
    }

    [Fact]
    public async Task Update_ValidIdAndCommand_ReturnsOkResult()
    {

        // Arrange
        var faker = new Faker();
        long id = 1;

        var command = new UpdateDriverCommand()
        {
            FirstName = faker.Person.FirstName,
            LastName = faker.Person.LastName,
            Email = faker.Internet.Email(),
            PhoneNumber = faker.Phone.PhoneNumber()
        };

        // Act
        var result = await _driverController.Update(id, command) as OkObjectResult;

        // Assert
        (((ApiResponse<object>)result.Value).Success).ShouldBe(true);
        result.ShouldNotBe(null);
    }

    [Fact]
    public async Task Delete_ValidId_ReturnsOkResult()
    {
        // Arrange
        long id = 1;

        // Act
        var result = await _driverController.Delete(id) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        (((ApiResponse<object>)result.Value).Success).ShouldBe(true);
    }



    [Fact]
    public async Task GetAlphabetizedUserNames_ReturnsOkResultWithSortedNamesList()
    {
        // Arrange
        var expectedSortedNamesList = new List<string> { "John", "Adam", "Tom" };

        _mediatorMock.Setup(m => m.Send(It.IsAny<GetAlphabetizedUserNamesQuery>(), default))
                     .ReturnsAsync(expectedSortedNamesList);


        // Act
        var result = await _driverController.GetAlphabetizedUserNames() as OkObjectResult;


        // Assert
        result.ShouldNotBeNull();
        ((ApiResponse<IEnumerable<string>>)result.Value).Data.ShouldBe(expectedSortedNamesList);
    }
}

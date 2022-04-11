using Microsoft.AspNetCore.Mvc;
using Models.ResponseModels;
using Models.TableReservationBracketsModels;
using Moq;
using NUnit.Framework;
using RestaurantApi.Controllers;
using Services.TableTimeBracketsService;

namespace ApiControllersTest;

[TestFixture]
public class AvailableRestaurantTablesControllerTests
{
    private AvailableRestaurantTablesController _availableRestaurantTablesController;
    private Mock<ITableTimeBracketService> _tableTimeBracketService;

    [SetUp]
    public void Setup()
    {
        _tableTimeBracketService = new();
        _availableRestaurantTablesController = new(_tableTimeBracketService.Object);
    }

    [Test]
    public async Task GetAllAvailableReservationBracketsForRestaurant_InputValidRestaurantIdAndDateOfRequestString_Verify_ReturnNotNull_ServiceCall()
    {
        //Arrange
        _tableTimeBracketService.Setup(method => method.GetAllTableReservationBracketsForRestaurantAsync(
                It.IsAny<string>(),
                It.IsAny<DateTime>(),
                It.IsAny<CancellationToken>()
            )).ReturnsAsync(new Response<TableReservationBracketDto>())
            .Verifiable();
        const string restaurantId = "valid id";
        var dateOfRequestString = DateTime.Now.AddDays(1).ToString("MM-dd-yyyy");

        //Act
        var result = await _availableRestaurantTablesController.GetAllAvailableReservationBracketsForRestaurant(restaurantId, dateOfRequestString,CancellationToken.None);

        //Assert
        Assert.NotNull(result);
        Assert.AreEqual(typeof(ObjectResult),result.GetType());
        _tableTimeBracketService.Verify(method => method.GetAllTableReservationBracketsForRestaurantAsync(
            It.IsAny<string>(),
            It.IsAny<DateTime>(),
            It.IsAny<CancellationToken>()),Times.Once);
    }

    [Test]
    public async Task GetAllAvailableReservationBracketsForRestaurant_InputInvalidRestaurantIdAndDateOfRequestString_Verify_ReturnNotNull_NoServiceCall()
    {
        //Arrange
        _tableTimeBracketService.Setup(method => method.GetAllTableReservationBracketsForRestaurantAsync(
                It.IsAny<string>(),
                It.IsAny<DateTime>(),
                It.IsAny<CancellationToken>()
            )).ReturnsAsync(new Response<TableReservationBracketDto>())
            .Verifiable();

        //Act
        var result = await _availableRestaurantTablesController.GetAllAvailableReservationBracketsForRestaurant(string.Empty, string.Empty,CancellationToken.None);

        //Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
        _tableTimeBracketService.Verify(method => method.GetAllTableReservationBracketsForRestaurantAsync(
            It.IsAny<string>(),
            It.IsAny<DateTime>(),
            It.IsAny<CancellationToken>()), Times.Never);
    }

    [Test]
    public async Task GetAllAvailableReservationBracketsForRestaurant_InputInvalidDateOfRequestString_PastDate_Verify_ReturnNotNull_NoServiceCall()
    {
        //Arrange
        _tableTimeBracketService.Setup(method => method.GetAllTableReservationBracketsForRestaurantAsync(
                It.IsAny<string>(),
                It.IsAny<DateTime>(),
                It.IsAny<CancellationToken>()
            )).ReturnsAsync(new Response<TableReservationBracketDto>())
            .Verifiable();
        var dateOfRequestString = DateTime.Now.AddDays(-1).ToString("MM-dd-yyyy");

        //Act
        var result = await _availableRestaurantTablesController.GetAllAvailableReservationBracketsForRestaurant(string.Empty, dateOfRequestString, CancellationToken.None);

        //Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
        _tableTimeBracketService.Verify(method => method.GetAllTableReservationBracketsForRestaurantAsync(
            It.IsAny<string>(),
            It.IsAny<DateTime>(),
            It.IsAny<CancellationToken>()), Times.Never);
    }

    [Test]
    public async Task GetAllAvailableReservationBracketsForRestaurant_InputInvalidDateOfRequestString_WrongDateFormat_Verify_ReturnNotNull_NoServiceCall()
    {
        //Arrange
        _tableTimeBracketService.Setup(method => method.GetAllTableReservationBracketsForRestaurantAsync(
                It.IsAny<string>(),
                It.IsAny<DateTime>(),
                It.IsAny<CancellationToken>()
            )).ReturnsAsync(new Response<TableReservationBracketDto>())
            .Verifiable();
        var dateOfRequestString = DateTime.Now.AddDays(-1).ToString("MM/dd/yyyy");

        //Act
        var result = await _availableRestaurantTablesController.GetAllAvailableReservationBracketsForRestaurant(string.Empty, dateOfRequestString, CancellationToken.None);

        //Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
        _tableTimeBracketService.Verify(method => method.GetAllTableReservationBracketsForRestaurantAsync(
            It.IsAny<string>(),
            It.IsAny<DateTime>(),
            It.IsAny<CancellationToken>()), Times.Never);
    }
}
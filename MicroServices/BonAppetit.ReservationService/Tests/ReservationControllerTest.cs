using System.Linq.Expressions;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Microsoft.AspNetCore.Mvc;
using Models.ReservationModels;
using Models.ResponseModels;
using Moq;
using NUnit.Framework;
using ReservationService.Controllers;
using Services.Repository.ReservationServices;

namespace Tests;

[TestFixture]
public class ReservationControllerTest
{
    private ReservationController _reservationController;
    private Mock<IReservationService> _reservationService;

    [SetUp]
    public void Setup()
    {
        _reservationService = new();
        _reservationController = new(_reservationService.Object);
    }

    [Test]
    public async Task GetAllReservationsForRestaurant_InputValidRestaurantId_Verify_ReturnType_RestaurantServiceCall()
    {
        //Arrange
        const string restaurantId = "id";
        _reservationService.Setup(method => method.GetByAsync(
            It.IsAny<Expression<Func<ReservationBase, bool>>>(),
            It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Response<ReservationDto>()).Verifiable();

        //Act
        var result = await _reservationController.GetAllReservationsForRestaurant(restaurantId, CancellationToken.None);

        //Assert
        Assert.NotNull(result);
        Assert.AreEqual(typeof(ObjectResult), result.GetType());
        _reservationService.Verify(method => method.GetByAsync(
            It.IsAny<Expression<Func<ReservationBase, bool>>>(),
            It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task GetAllReservationsForRestaurant_InputInvalidRestaurantId_Verify_ReturnType_NoRestaurantServiceCall()
    {
        //Act
        var result = await _reservationController.GetAllReservationsForRestaurant(string.Empty, CancellationToken.None);

        //Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
        _reservationService.Verify(method => method.GetByAsync(
            It.IsAny<Expression<Func<ReservationBase, bool>>>(),
            It.IsAny<CancellationToken>()), Times.Never);
    }

    [Test]
    public async Task GetAllExpiredReservationsForRestaurant_InputValidRestaurantId_Verify_ReturnType_RestaurantServiceCall()
    {
        //Arrange
        const string restaurantId = "id";
        _reservationService.Setup(method => method.GetByAsync(
                It.IsAny<Expression<Func<ReservationBase, bool>>>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Response<ReservationDto>()).Verifiable();

        //Act
        var result = await _reservationController.GetAllExpiredReservationsForRestaurant(restaurantId, CancellationToken.None);

        //Assert
        Assert.NotNull(result);
        Assert.AreEqual(typeof(ObjectResult), result.GetType());
        _reservationService.Verify(method => method.GetByAsync(
            It.IsAny<Expression<Func<ReservationBase, bool>>>(),
            It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task GetAllExpiredReservationsForRestaurant_InputInvalidRestaurantId_Verify_ReturnType_NoRestaurantServiceCall()
    {
        //Act
        var result = await _reservationController.GetAllExpiredReservationsForRestaurant(string.Empty, CancellationToken.None);

        //Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
        _reservationService.Verify(method => method.GetByAsync(
            It.IsAny<Expression<Func<ReservationBase, bool>>>(),
            It.IsAny<CancellationToken>()), Times.Never);
    }

    [Test]
    public async Task GetAllValidReservationsForClient_InputValidRestaurantId_Verify_ReturnType_RestaurantServiceCall()
    {
        //Arrange
        const string clientId = "id";
        _reservationService.Setup(method => method.GetByAsync(
                It.IsAny<Expression<Func<ReservationBase, bool>>>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Response<ReservationDto>()).Verifiable();

        //Act
        var result = await _reservationController.GetAllValidReservationsForClient(clientId, CancellationToken.None);

        //Assert
        Assert.NotNull(result);
        Assert.AreEqual(typeof(ObjectResult), result.GetType());
        _reservationService.Verify(method => method.GetByAsync(
            It.IsAny<Expression<Func<ReservationBase, bool>>>(),
            It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task GetAllValidReservationsForClient_InputInvalidRestaurantId_Verify_ReturnType_NoRestaurantServiceCall()
    {
        //Act
        var result = await _reservationController.GetAllValidReservationsForClient(string.Empty, CancellationToken.None);

        //Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
        _reservationService.Verify(method => method.GetByAsync(
            It.IsAny<Expression<Func<ReservationBase, bool>>>(),
            It.IsAny<CancellationToken>()), Times.Never);
    }

    [Test]
    public async Task GetAllExpiredReservationsForClient_InputValidRestaurantId_Verify_ReturnType_RestaurantServiceCall()
    {
        //Arrange
        const string clientId = "id";
        _reservationService.Setup(method => method.GetByAsync(
                It.IsAny<Expression<Func<ReservationBase, bool>>>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Response<ReservationDto>()).Verifiable();

        //Act
        var result = await _reservationController.GetAllExpiredReservationsForClient(clientId, CancellationToken.None);

        //Assert
        Assert.NotNull(result);
        Assert.AreEqual(typeof(ObjectResult), result.GetType());
        _reservationService.Verify(method => method.GetByAsync(
            It.IsAny<Expression<Func<ReservationBase, bool>>>(),
            It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task GetAllExpiredReservationsForClient_InputInvalidRestaurantId_Verify_ReturnType_NoRestaurantServiceCall()
    {
        //Act
        var result = await _reservationController.GetAllExpiredReservationsForClient(string.Empty, CancellationToken.None);

        //Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
        _reservationService.Verify(method => method.GetByAsync(
            It.IsAny<Expression<Func<ReservationBase, bool>>>(),
            It.IsAny<CancellationToken>()), Times.Never);
    }

    [Test]
    public async Task GetReservationsForSingleTable_InputValidRestaurantId_Verify_ReturnType_RestaurantServiceCall()
    {
        //Arrange
        const string tableId = "id";
        _reservationService.Setup(method => method.GetByAsync(
                It.IsAny<Expression<Func<ReservationBase, bool>>>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Response<ReservationDto>()).Verifiable();

        //Act
        var result = await _reservationController.GetReservationsForSingleTable(tableId, CancellationToken.None);

        //Assert
        Assert.NotNull(result);
        Assert.AreEqual(typeof(ObjectResult), result.GetType());
        _reservationService.Verify(method => method.GetByAsync(
            It.IsAny<Expression<Func<ReservationBase, bool>>>(),
            It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task GetReservationsForSingleTable_InputInvalidRestaurantId_Verify_ReturnType_NoRestaurantServiceCall()
    {
        //Act
        var result = await _reservationController.GetReservationsForSingleTable(string.Empty, CancellationToken.None);

        //Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
        _reservationService.Verify(method => method.GetByAsync(
            It.IsAny<Expression<Func<ReservationBase, bool>>>(),
            It.IsAny<CancellationToken>()), Times.Never);
    }

    [Test]
    public async Task MakeReservation_InputValidReservationCreateModel_Verify_ReturnNotNull_ServiceCall()
    {
        //Arrange
        var reservationToMake = new ReservationCreate();
        _reservationService.Setup(method => method.MakeReservationAsync(
                It.IsAny<ReservationCreate>(),
                It.IsAny<CancellationToken>()
                )).ReturnsAsync(new Response<ReservationDto>()).Verifiable();

        //Act
        var result = await _reservationController.MakeReservation(reservationToMake, CancellationToken.None);

        //Assert
        Assert.NotNull(result);
        Assert.AreEqual(typeof(ObjectResult),result.GetType());
        _reservationService.Verify(method => method.MakeReservationAsync(
            It.IsAny<ReservationCreate>(),
            It.IsAny<CancellationToken>()
        ),Times.Once);
    }

    [Test]
    public async Task MakeReservation_InputInvalidReservationCreateModel_Verify_ReturnNotNull_NoServiceCall()
    {
        //Arrange
        _reservationService.Setup(method => method.MakeReservationAsync(
            It.IsAny<ReservationCreate>(),
            It.IsAny<CancellationToken>()
        )).ReturnsAsync(new Response<ReservationDto>()).Verifiable();
        var reservationToMake = new ReservationCreate();
        _reservationController.ModelState.AddModelError("test","test");

        //Act
        var result = await _reservationController.MakeReservation(reservationToMake, CancellationToken.None);

        //Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
        _reservationService.Verify(method => method.MakeReservationAsync(
            It.IsAny<ReservationCreate>(),
            It.IsAny<CancellationToken>()
        ), Times.Never);
    }
}

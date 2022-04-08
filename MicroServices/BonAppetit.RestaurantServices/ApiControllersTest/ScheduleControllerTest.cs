using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Models.ResponseModels;
using Models.ScheduleModels;
using Moq;
using NUnit.Framework;
using RestaurantApi.Controllers;
using Services.Repository.ScheduleRepository;

namespace ApiControllersTest;

[TestFixture]
public class ScheduleControllerTest
{
    private ScheduleController _scheduleController;
    private Mock<IScheduleService> _scheduleService;

    [SetUp]
    public void Setup()
    {
        _scheduleService = new();
        _scheduleController = new(_scheduleService.Object);
    }

    [Test]
    public async Task GetSingleRestaurantSchedule_Verify_ReturnNotNull_ReturnType_ScheduleServiceCall()
    {
        //Arrange
        const string restaurantId = "id";
        _scheduleService.Setup(method => method.GetSingleByAsync(
            It.IsAny<Expression<Func<ScheduleBase, bool>>>(),
            It.IsAny<CancellationToken>(),
            It.IsAny<Expression<Func<ScheduleBase, object>>[]>()))
            .ReturnsAsync(new Response<ScheduleDto>()).Verifiable();

        //Act
        var result = await _scheduleController.GetSingleRestaurantSchedule(restaurantId, CancellationToken.None);

        //Assert
        Assert.NotNull(result);
        Assert.AreEqual(typeof(ObjectResult),result.GetType());
        _scheduleService.Verify(method => method.GetSingleByAsync(
            It.IsAny<Expression<Func<ScheduleBase, bool>>>(),
            It.IsAny<CancellationToken>(),
            It.IsAny<Expression<Func<ScheduleBase, object>>[]>()),Times.Once);
    }

    [Test]
    public async Task GetSingleRestaurantSchedule_InputNulOrWhiteSpacedRestaurantId_ReturnBadRequest_Verify_ScheduleServiceNoCall()
    {
        //Arrange
        var restaurantId = string.Empty;
        _scheduleService.Setup(method => method.GetSingleByAsync(
                It.IsAny<Expression<Func<ScheduleBase, bool>>>(),
                It.IsAny<CancellationToken>(),
                It.IsAny<Expression<Func<ScheduleBase, object>>[]>()))
            .Verifiable();

        //Act
        var result = await _scheduleController.GetSingleRestaurantSchedule(restaurantId, CancellationToken.None);

        Assert.NotNull(result);
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
        _scheduleService.Verify(method => method.GetSingleByAsync(
            It.IsAny<Expression<Func<ScheduleBase, bool>>>(),
            It.IsAny<CancellationToken>(),
            It.IsAny<Expression<Func<ScheduleBase, object>>[]>()),Times.Never);
    }

    [Test]
    public async Task CreateSingleRestaurantSchedule_Verify_ReturnNotNull_ReturnType_ScheduleServiceCall()
    {
        //Arrange
        var objectToCreate = new ScheduleCreate();
        _scheduleService.Setup(method => method.CreateAsync(
                It.IsAny<ScheduleCreate>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Response<ScheduleDto>()).Verifiable();

        //Act
        var result = await _scheduleController.CreateSingleRestaurantSchedule(objectToCreate, CancellationToken.None);

        //Assert
        Assert.NotNull(result);
        Assert.AreEqual(typeof(ObjectResult), result.GetType());
        _scheduleService.Verify(method => method.CreateAsync(
                It.IsAny<ScheduleCreate>(),
                It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task CreateSingleRestaurantSchedule_InputInvalidScheduleCreate_ReturnBadRequest_Verify_ScheduleServiceNoCall()
    {
        //Arrange
        var objectToCreate = new ScheduleCreate();
        _scheduleService.Setup(method => method.CreateAsync(
                It.IsAny<ScheduleCreate>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Response<ScheduleDto>()).Verifiable();
        _scheduleController.ModelState.AddModelError("test","test");

        //Act
        var result = await _scheduleController.CreateSingleRestaurantSchedule(objectToCreate, CancellationToken.None);

        //Assert
        Assert.NotNull(result);
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
        _scheduleService.Verify(method => method.CreateAsync(
            It.IsAny<ScheduleCreate>(),
            It.IsAny<CancellationToken>()), Times.Never);
    }

    [Test]
    public async Task UpdateSingleRestaurantSchedule_Verify_ReturnNotNull_ReturnType_ScheduleServiceCall()
    {
        //Arrange
        _scheduleService.Setup(method => method.UpdateAsync(
                It.IsAny<ScheduleUpdate>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Response<ScheduleDto>()).Verifiable();

        //Act
        var result = await _scheduleController.UpdateSingleRestaurantSchedule(new ScheduleUpdate(), CancellationToken.None);

        //Assert
        Assert.NotNull(result);
        Assert.AreEqual(typeof(ObjectResult),result.GetType());
        _scheduleService.Verify(method => method.UpdateAsync(
            It.IsAny<ScheduleUpdate>(),
            It.IsAny<CancellationToken>()),Times.Once);
    }

    [Test]
    public async Task UpdateSingleRestaurantSchedule_InputInvalidScheduleDto_ReturnBadRequest_Verify_ScheduleServiceNoCall()
    {
        //Arrange
        _scheduleService.Setup(method => method.UpdateAsync(
                It.IsAny<ScheduleUpdate>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Response<ScheduleDto>()).Verifiable();
        _scheduleController.ModelState.AddModelError("test","test");

        //Act
        var result = await _scheduleController.UpdateSingleRestaurantSchedule(new ScheduleUpdate(), CancellationToken.None);

        //Assert
        Assert.NotNull(result);
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
        _scheduleService.Verify(method => method.UpdateAsync(
            It.IsAny<ScheduleUpdate>(),
            It.IsAny<CancellationToken>()), Times.Never);
    }

    [Test]
    public async Task DeleteSingleRestaurantSchedule_Verify_ReturnNotNull_ReturnType_ScheduleServiceCall()
    {
        //Arrange
        const string restaurantId = "id";
        _scheduleService.Setup(method => method.DeleteAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Response<ScheduleDto>()).Verifiable();

        //Act
        var result = await _scheduleController.DeleteSingleRestaurantSchedule(restaurantId, CancellationToken.None);

        //Assert
        Assert.NotNull(result);
        Assert.AreEqual(typeof(ObjectResult), result.GetType());
        _scheduleService.Verify(method => method.DeleteAsync(
            It.IsAny<string>(),
            It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task DeleteSingleRestaurantSchedule_InputInvalidRestaurantId_ReturnBadRequest_Verify_ScheduleServiceNoCall()
    {
        //Arrange
        var restaurantId = string.Empty;
        _scheduleService.Setup(method => method.DeleteAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Response<ScheduleDto>()).Verifiable();
        _scheduleController.ModelState.AddModelError("test", "test");

        //Act
        var result = await _scheduleController.DeleteSingleRestaurantSchedule(restaurantId, CancellationToken.None);

        //Assert
        Assert.NotNull(result);
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
        _scheduleService.Verify(method => method.DeleteAsync(
            It.IsAny<string>(),
            It.IsAny<CancellationToken>()), Times.Never);
    }
}
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Models.ResponseModels;
using Models.RestaurantModels;
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
    public async Task GetSingleRestaurantSchedule_InputNulOrWhiteSpacedRestaurantId_ReturnBadRequest_Veify_ScheduleServiceNoCall()
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


}
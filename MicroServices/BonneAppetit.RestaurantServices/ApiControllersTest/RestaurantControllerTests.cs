using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Models.ResponseModels;
using Models.RestaurantModels;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using RestaurantApi.Controllers;
using Services.Repository.RestaurantRepository;

namespace ApiControllersTest;

[TestFixture]
public class RestaurantControllerTests
{
    private RestaurantController _restaurantController;
    private Mock<IRestaurantService> _restaurantService;

    [SetUp]
    public void Setup()
    {
        _restaurantService = new Mock<IRestaurantService>();
        _restaurantController = new RestaurantController(_restaurantService.Object);
    }

    [Test]
    public async Task GetAllRestaurants_Verify_ReturnNotNull_ReturnType_RestaurantServiceGetAllByAsyncCall()
    {
        //Arrange
        //ExpectedResult
        var expectedResponse = new Response<RestaurantDto>
        {
            StatusCode = 200, IsSuccessful = true, Title = "Ok", Message = "Ok", ResponseObject = new List<RestaurantDto>()
        };
        _restaurantService.Setup(method => method.GetAllByAsync(
            It.IsAny<Expression<Func<RestaurantBase, bool>>>(),
            It.IsAny<CancellationToken>(),
            It.IsAny<Expression<Func<RestaurantBase, object>>[]>())).ReturnsAsync(expectedResponse).Verifiable();

        //Act
        var result = await _restaurantController.GetAllRestaurants(CancellationToken.None);

        //Assert
        Assert.NotNull(result);
        Assert.AreEqual(typeof(ObjectResult),result.GetType());
        _restaurantService.Verify(method=>method.GetAllByAsync(
            It.IsAny<Expression<Func<RestaurantBase, bool>>>(),
            It.IsAny<CancellationToken>(),
            It.IsAny<Expression<Func<RestaurantBase, object>>[]>()),Times.Once);
        Assert.AreEqual(expectedResponse,
            await _restaurantService.Object.GetAllByAsync(
            It.IsAny<Expression<Func<RestaurantBase, bool>>>(),
            It.IsAny<CancellationToken>(),
            It.IsAny<Expression<Func<RestaurantBase, object>>[]>()));
    }
}
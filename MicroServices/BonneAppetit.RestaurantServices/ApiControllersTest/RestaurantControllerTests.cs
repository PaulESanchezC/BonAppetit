using System.Linq.Expressions;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Models.ResponseModels;
using Models.RestaurantModels;
using Moq;
using NUnit.Framework;
using RestaurantApi.Controllers;
using Services.Repository.RestaurantRepository;
using ObjectResult = Microsoft.AspNetCore.Mvc.ObjectResult;

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
    public async Task GetAllRestaurants_Verify_ReturnNotNull_ReturnType_RestaurantServiceCall()
    {
        //Expected Result
        var expectedResponse = new Response<RestaurantDto>
        {
            StatusCode = 200,
            IsSuccessful = true,
            Title = "Ok",
            Message = "Ok",
            ResponseObject = new List<RestaurantDto>()
        };
        //Arrange
        _restaurantService.Setup(method => method.GetAllByAsync(
            It.IsAny<Expression<Func<RestaurantBase, bool>>>(),
            It.IsAny<CancellationToken>(),
            It.IsAny<Expression<Func<RestaurantBase, object>>[]>())).ReturnsAsync(expectedResponse).Verifiable();

        //Act
        var result = await _restaurantController.GetAllRestaurants(CancellationToken.None);

        //Assert
        Assert.NotNull(result);
        Assert.AreEqual(typeof(ObjectResult), result.GetType());
        _restaurantService.Verify(method => method.GetAllByAsync(
            It.IsAny<Expression<Func<RestaurantBase, bool>>>(),
            It.IsAny<CancellationToken>(),
            It.IsAny<Expression<Func<RestaurantBase, object>>[]>()), Times.Once);
    }

    [Test]
    public async Task GetSingleRestaurantById_Verify_ReturnNotNull_ReturnType_RestaurantServiceCall()
    {
        //Arrange
        const string restaurantId = "guid id";
        //Expected Result
        var expectedResponse = new Response<RestaurantDto>
        {
            StatusCode = 200,
            IsSuccessful = true,
            Title = "Ok",
            Message = "Ok",
            ResponseObject = new List<RestaurantDto>
            {
                new ()
                {
                    RestaurantId = restaurantId
                }
            }
        };

        _restaurantService.Setup(method => method.GetSingleByAsync(
                It.IsAny<Expression<Func<RestaurantBase, bool>>>(),
                It.IsAny<CancellationToken>(),
                It.IsAny<Expression<Func<RestaurantBase, object>>[]>())).ReturnsAsync(expectedResponse).Verifiable();

        //Act
        var result = await _restaurantController.GetSingleRestaurant(restaurantId, CancellationToken.None);

        //Assert
        Assert.NotNull(result);
        Assert.AreEqual(typeof(ObjectResult), result.GetType());
        _restaurantService.Verify(method => method.GetSingleByAsync(
            It.IsAny<Expression<Func<RestaurantBase, bool>>>(),
            It.IsAny<CancellationToken>(),
            It.IsAny<Expression<Func<RestaurantBase, object>>[]>()), Times.Once);
    }

    [Test]
    public async Task GetSingleRestaurantById_InputNullOrWhiteSpaceId_ReturnBadRequest_Verify_RestaurantServiceNoCall_ReturnType()
    {
        const string restaurantId = "";
        _restaurantService.Setup(method => method.GetSingleByAsync(It.IsAny<Expression<Func<RestaurantBase, bool>>>(),
            It.IsAny<CancellationToken>(),
            It.IsAny<Expression<Func<RestaurantBase, object>>[]>())).Verifiable();

        //Act
        var result = await _restaurantController.GetSingleRestaurant(restaurantId, CancellationToken.None) as ObjectResult;

        //Assert
        Assert.NotNull(result);
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
        _restaurantService.Verify(method => method.GetSingleByAsync(It.IsAny<Expression<Func<RestaurantBase, bool>>>(),
            It.IsAny<CancellationToken>(),
            It.IsAny<Expression<Func<RestaurantBase, object>>[]>()), Times.Never);
    }

    [Test]
    public async Task CreateSingleRestaurant_Verify_ReturnNotNull_ReturnType_RestaurantServiceCall()
    {
        //Arrange
        //Expected Result
        var expectedResponse = new Response<RestaurantDto>
        {
            StatusCode = 200,
            IsSuccessful = true,
            Title = "Ok",
            Message = "Ok",
            ResponseObject = new()
        };

        var objectToCreateFromBody = new RestaurantCreate
        {
            RestaurantName = "name",
            RestaurantAddress = "address",
            RestaurantCiy = "city",
            RestaurantCuisineType = "cuisine",
            RestaurantPhone = "phone",
            RestaurantWebsite = "website"
        };
        _restaurantService.Setup(method => method.CreateAsync(
            It.IsAny<RestaurantCreate>(),
            It.IsAny<CancellationToken>()
        )).ReturnsAsync(expectedResponse).Verifiable();

        //Act
        var result = await _restaurantController.CreateSingleRestaurant(objectToCreateFromBody, CancellationToken.None);

        //Assert
        Assert.NotNull(result);
        Assert.AreEqual(typeof(ObjectResult), result.GetType());
        _restaurantService.Verify(method => method.CreateAsync(
            It.IsAny<RestaurantCreate>(),
            It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task CreateSingleRestaurant_InputInvalidModelState_ReturnBadRequest_Verify_RestaurantServiceNoCall_ReturnType()
    {
        //Arrange
        var objectToCreateFromBody = new RestaurantCreate();

        _restaurantController.ModelState.AddModelError("test", "test");
        _restaurantService.Setup(method => method.CreateAsync(
            It.IsAny<RestaurantCreate>(),
            It.IsAny<CancellationToken>()
        )).Verifiable();

        //Act
        var result = await _restaurantController.CreateSingleRestaurant(objectToCreateFromBody, CancellationToken.None);

        //Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
        Assert.NotNull(result);
        _restaurantService.Verify(method => method.CreateAsync(
            It.IsAny<RestaurantCreate>(),
            It.IsAny<CancellationToken>()), Times.Never);
    }

    [Test]
    public async Task UpdateSingleRestaurant_Verify_ReturnNotNull_ReturnType_RestaurantServiceCall()
    {
        //Arrange
        //Expected Result
        var expectedResponse = new Response<RestaurantDto>
        {
            StatusCode = 200,
            IsSuccessful = true,
            Title = "Ok",
            Message = "Ok",
            ResponseObject = new()
        };
        var objectToUpdateFromBody = new RestaurantDto()
        {
            RestaurantId = "id",
            RestaurantName = "name",
            RestaurantAddress = "address",
            RestaurantCiy = "city",
            RestaurantCuisineType = "cuisine",
            RestaurantPhone = "phone",
            RestaurantWebsite = "website"
        };
        _restaurantService.Setup(method => method.UpdateAsync(
            It.IsAny<RestaurantDto>(),
            It.IsAny<CancellationToken>()
        )).ReturnsAsync(expectedResponse).Verifiable();

        //Act
        var result = await _restaurantController.UpdateSingleRestaurant(objectToUpdateFromBody, CancellationToken.None);

        //Assert
        Assert.NotNull(result);
        Assert.AreEqual(typeof(ObjectResult), result.GetType());
        _restaurantService.Verify(method => method.UpdateAsync(
            It.IsAny<RestaurantDto>(),
            It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task UpdateSingleRestaurant_InputInvalidModelState_ReturnBadRequest_Verify_RestaurantServiceNoCall_ReturnType()
    {
        //Arrange
        var objectToUpdateFromBody = new RestaurantDto();

        _restaurantController.ModelState.AddModelError("test", "test");
        _restaurantService.Setup(method => method.UpdateAsync(
            It.IsAny<RestaurantDto>(),
            It.IsAny<CancellationToken>()
        )).Verifiable();

        //Act
        var result = await _restaurantController.UpdateSingleRestaurant(objectToUpdateFromBody, CancellationToken.None);

        //Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
        Assert.NotNull(result);
        _restaurantService.Verify(method => method.UpdateAsync(
            It.IsAny<RestaurantDto>(),
            It.IsAny<CancellationToken>()), Times.Never);

    }

    [Test]
    public async Task DeleteSingleRestaurant__Verify_ReturnNotNull_ReturnType_RestaurantServiceCall()
    {
        //Expected Result
        var expectedResponse = new Response<RestaurantDto>();
        //Arrange
        const string restaurantId = "id";
        _restaurantService.Setup(method => method.DeleteAsync(
            It.IsAny<string>(),
            It.IsAny<CancellationToken>()
        )).ReturnsAsync(expectedResponse).Verifiable();

        //Act
        var result = await _restaurantController.DeleteSingleRestaurant(restaurantId, CancellationToken.None);

        //Assert
        Assert.NotNull(result);
        Assert.AreEqual(typeof(ObjectResult), result.GetType());
        _restaurantService.Verify(method => method.DeleteAsync(
            It.IsAny<string>(),
            It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task DeleteSingleRestaurant_InputNullOrWhiteSpaceId_ReturnBadRequest_Verify_RestaurantServiceNoCall_ReturnType()
    {
        //Arrange
        _restaurantService.Setup(method => method.DeleteAsync(
            It.IsAny<string>(),
            It.IsAny<CancellationToken>()
        )).Verifiable();
        _restaurantController.ModelState.AddModelError("test","test");

        //Act
        var result = await _restaurantController.DeleteSingleRestaurant(string.Empty, CancellationToken.None);

        //Assert
        Assert.NotNull(result);
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
        _restaurantService.Verify(method => method.DeleteAsync(
            It.IsAny<string>(),
            It.IsAny<CancellationToken>()), Times.Never);
    }
}

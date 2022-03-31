using System.Linq.Expressions;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Microsoft.AspNetCore.Mvc;
using Models.MenuModels;
using Models.ResponseModels;
using Moq;
using NUnit.Framework;
using RestaurantApi.Controllers;
using Services.Repository.MenuRepository;

namespace ApiControllersTest;

[TestFixture]
public class RestaurantMenuControllerTest
{
    private Mock<IMenuService> _menuService;
    private RestaurantMenuController _restaurantMenuController;

    [SetUp]
    public void Setup()
    {
        _menuService = new Mock<IMenuService>();
        _restaurantMenuController = new(_menuService.Object);
    }

    [Test]
    public async Task GetAllRestaurantMenus_InputValidRestaurantId_Verify_ReturnNotNull_ReturnType_MenuServiceCall()
    {
        //Arrange
        _menuService.Setup(method => method.GetAllByAsync(
            It.IsAny<Expression<Func<MenuBase, bool>>>(),
            It.IsAny<CancellationToken>(),
            It.IsAny<Expression<Func<MenuBase,object>>[]>()
        )).ReturnsAsync(new Response<MenuDto>()).Verifiable();
        const string restaurantId = "id";

        //Act
        var result = await _restaurantMenuController.GetAllRestaurantMenus(restaurantId, CancellationToken.None);

        //Assert
        Assert.NotNull(result);
        Assert.AreEqual(typeof(ObjectResult),result.GetType());
        _menuService.Verify(method => method.GetAllByAsync(
            It.IsAny<Expression<Func<MenuBase, bool>>>(),
            It.IsAny<CancellationToken>(),
            It.IsAny<Expression<Func<MenuBase, object>>[]>()),Times.Once);
    }

    [Test]
    public async Task GetAllRestaurantMenus_InputInvalidRestaurantId_Verify_ReturnNotNull_ReturnType_NoMenuServiceCall()
    {
        //Expected Results
        const string modelStateErrorString = "The restaurantId field is required.";
        //Arrange
        _menuService.Setup(method => method.GetAllByAsync(
            It.IsAny<Expression<Func<MenuBase, bool>>>(),
            It.IsAny<CancellationToken>(),
            It.IsAny<Expression<Func<MenuBase, object>>[]>()
        )).ReturnsAsync(new Response<MenuDto>()).Verifiable();
        
        //Act
        var result = await _restaurantMenuController.GetAllRestaurantMenus(string.Empty, CancellationToken.None);
        
        //Assert
        Assert.NotNull(result);
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
        _menuService.Verify(method => method.GetAllByAsync(
            It.IsAny<Expression<Func<MenuBase, bool>>>(),
            It.IsAny<CancellationToken>(),
            It.IsAny<Expression<Func<MenuBase, object>>[]>()), Times.Never);        
    }

    [Test]
    public async Task GetSingleRestaurantMenu_InputValidMenuId_Verify_ReturnNotNull_ReturnType_MenuServiceCall()
    {
        //Arrange
        _menuService.Setup(method => method.GetSingleByAsync(
            It.IsAny<Expression<Func<MenuBase, bool>>>(),
            It.IsAny<CancellationToken>(),
            It.IsAny<Expression<Func<MenuBase, object>>[]>()
        )).ReturnsAsync(new Response<MenuDto>()).Verifiable();
        const string menuId = "id";

        //Act
        var result = await _restaurantMenuController.GetSingleRestaurantMenu(menuId, CancellationToken.None);

        //Assert
        Assert.NotNull(result);
        Assert.AreEqual(typeof(ObjectResult), result.GetType());
        _menuService.Verify(method => method.GetSingleByAsync(
            It.IsAny<Expression<Func<MenuBase, bool>>>(),
            It.IsAny<CancellationToken>(),
            It.IsAny<Expression<Func<MenuBase, object>>[]>()), Times.Once);
    }

    [Test]
    public async Task GetSingleRestaurantMenu_InputInvalidMenuId_Verify_ReturnNotNull_ReturnType_NoMenuServiceCall()
    {
        //Arrange
        _menuService.Setup(method => method.GetSingleByAsync(
            It.IsAny<Expression<Func<MenuBase, bool>>>(),
            It.IsAny<CancellationToken>(),
            It.IsAny<Expression<Func<MenuBase, object>>[]>()
        )).ReturnsAsync(new Response<MenuDto>()).Verifiable();

        //Act
        var result = await _restaurantMenuController.GetAllRestaurantMenus(string.Empty, CancellationToken.None);

        //Assert
        Assert.NotNull(result);
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
        _menuService.Verify(method => method.GetSingleByAsync(
            It.IsAny<Expression<Func<MenuBase, bool>>>(),
            It.IsAny<CancellationToken>(),
            It.IsAny<Expression<Func<MenuBase, object>>[]>()), Times.Never);
    }

    [Test]
    public async Task CreateRestaurantMenu_InputValidRestaurantId_Verify_ReturnNotNull_ReturnType_MenuServiceCall()
    {
        //Arrange
        _menuService.Setup(method => method.CreateAsync(
            It.IsAny<MenuCreate>(),
            It.IsAny<CancellationToken>()
        )).ReturnsAsync(new Response<MenuDto>()).Verifiable();
        var menuToCreate = new MenuCreate();
        
        //Act
        var result = await _restaurantMenuController.CreateRestaurantMenu(menuToCreate, CancellationToken.None);

        //Assert
        Assert.NotNull(result);
        Assert.AreEqual(typeof(ObjectResult), result.GetType());
        _menuService.Verify(method => method.CreateAsync(
            It.IsAny<MenuCreate>(),
            It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task CreateRestaurantMenu_InputInvalidRestaurantId_Verify_ReturnNotNull_ReturnType_NoMenuServiceCall()
    {
        //Arrange
        _menuService.Setup(method => method.CreateAsync(
            It.IsAny<MenuCreate>(),
            It.IsAny<CancellationToken>()
        )).ReturnsAsync(new Response<MenuDto>()).Verifiable();
        _restaurantMenuController.ModelState.AddModelError("test","test");
        var menuToCreate = new MenuCreate();

        //Act
        var result = await _restaurantMenuController.CreateRestaurantMenu(menuToCreate,CancellationToken.None);

        //Assert
        Assert.NotNull(result);
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
        _menuService.Verify(method => method.CreateAsync(
            It.IsAny<MenuCreate>(),
            It.IsAny<CancellationToken>()), Times.Never);
    }

    [Test]
    public async Task SetRestaurantMenuPublicValue_InputValidMenuIdSetPublic_Verify_ReturnNotNull_ReturnType_MenuServiceCall()
    {
        //Arrange
        _menuService.Setup(method => method.SetMenuPublicValueAsync(
            It.IsAny<string>(),
            It.IsAny<bool>(),
            It.IsAny<CancellationToken>()
        )).ReturnsAsync(new Response<MenuDto>()).Verifiable();
        const string menuId = "id";
        const bool setPublic = false;

        //Act
        var result = await _restaurantMenuController.SetRestaurantMenuPublicValue(menuId,setPublic, CancellationToken.None);

        //Assert
        Assert.NotNull(result);
        Assert.AreEqual(typeof(ObjectResult), result.GetType());
        _menuService.Verify(method => method.SetMenuPublicValueAsync(
            It.IsAny<string>(),
            It.IsAny<bool>(),
        It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task SetRestaurantMenuPublicValue_InputInvalidMenuIdSetPublic_Verify_ReturnNotNull_ReturnType_NoMenuServiceCall()
    {
        //Arrange
        _menuService.Setup(method => method.SetMenuPublicValueAsync(
            It.IsAny<string>(),
            It.IsAny<bool>(),
            It.IsAny<CancellationToken>()
        )).ReturnsAsync(new Response<MenuDto>()).Verifiable();
        
        //Act
        var result = await _restaurantMenuController.SetRestaurantMenuPublicValue(string.Empty, null,CancellationToken.None);

        //Assert
        Assert.NotNull(result);
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
        _menuService.Verify(method => method.SetMenuPublicValueAsync(
            It.IsAny<string>(),
            It.IsAny<bool>(),
            It.IsAny<CancellationToken>()), Times.Never);
    }

    [Test]
    public async Task UpdateRestaurantMenu_InputValidMenuDto_Verify_ReturnNotNull_ReturnType_MenuServiceCall()
    {
        //Arrange
        _menuService.Setup(method => method.UpdateAsync(
            It.IsAny<MenuDto>(),
            It.IsAny<CancellationToken>()
        )).ReturnsAsync(new Response<MenuDto>()).Verifiable();
        var menuToUpdate = new MenuDto();

        //Act
        var result = await _restaurantMenuController.UpdateRestaurantMenu(menuToUpdate,CancellationToken.None);

        //Assert
        Assert.NotNull(result);
        Assert.AreEqual(typeof(ObjectResult), result.GetType());
        _menuService.Verify(method => method.UpdateAsync(
            It.IsAny<MenuDto>(),
            It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task UpdateRestaurantMenu_InputInvalidMenuDto_Verify_ReturnNotNull_ReturnType_NoMenuServiceCall()
    {
        //Arrange
        _menuService.Setup(method => method.UpdateAsync(
            It.IsAny<MenuDto>(),
            It.IsAny<CancellationToken>()
        )).ReturnsAsync(new Response<MenuDto>()).Verifiable();
        var menuToUpdate = new MenuDto();
        _restaurantMenuController.ModelState.AddModelError("test","test");

        //Act
        var result = await _restaurantMenuController.UpdateRestaurantMenu(menuToUpdate, CancellationToken.None);

        //Assert
        Assert.NotNull(result);
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
        _menuService.Verify(method => method.UpdateAsync(
            It.IsAny<MenuDto>(),
            It.IsAny<CancellationToken>()), Times.Never);
    }

    [Test]
    public async Task DeleteRestaurantMenu_InputValidMenuId_Verify_ReturnNotNull_ReturnType_MenuServiceCall()
    {
        //Arrange
        _menuService.Setup(method => method.DeleteAsync(
            It.IsAny<string>(),
            It.IsAny<CancellationToken>()
        )).ReturnsAsync(new Response<MenuDto>()).Verifiable();
        const string menuId = "id";
        
        //Act
        var result = await _restaurantMenuController.DeleteRestaurantMenu(menuId, CancellationToken.None);

        //Assert
        Assert.NotNull(result);
        Assert.AreEqual(typeof(ObjectResult), result.GetType());
        _menuService.Verify(method => method.DeleteAsync(
            It.IsAny<string>(),
            It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task DeleteRestaurantMenu_InputInvalidMenuId_Verify_ReturnNotNull_ReturnType_NoMenuServiceCall()
    {
        //Arrange
        _menuService.Setup(method => method.DeleteAsync(
            It.IsAny<string>(),
            It.IsAny<CancellationToken>()
        )).ReturnsAsync(new Response<MenuDto>()).Verifiable();

        //Act
        var result = await _restaurantMenuController.DeleteRestaurantMenu(string.Empty, CancellationToken.None);

        //Assert
        Assert.NotNull(result);
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
        _menuService.Verify(method => method.DeleteAsync(
            It.IsAny<string>(),
            It.IsAny<CancellationToken>()), Times.Never);
    }
}
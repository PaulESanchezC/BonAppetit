using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Models.ResponseModels;
using Models.TableModels;
using Moq;
using NUnit.Framework;
using RestaurantApi.Controllers;
using Services.Repository.TableRepository;

namespace ApiControllersTest;

[TestFixture]
public class TableControllerTest
{
    private TableController _tableController;
    private Mock<ITableService> _tableService;

    [SetUp]
    public void Setup()
    {
        _tableService = new();
        _tableController = new(_tableService.Object);
    }

    [Test]
    public async Task GetAllRestaurantTable_InputValidRestaurantId_ReturnNotNull_ReturnType_ScheduleServiceCall()
    {
        //Arrange
        _tableService.Setup(method => method.GetAllByAsync(
            It.IsAny<Expression<Func<TableBase, bool>>>(),
            It.IsAny<CancellationToken>(),
            It.IsAny<Expression<Func<TableBase, object>>[]>()))
            .ReturnsAsync(new Response<TableDto>()).Verifiable();
        const string restaurantId = "id";

        //Act
        var result = await _tableController.GetAllRestaurantTable(restaurantId, CancellationToken.None);

        //Arrange
        Assert.NotNull(result);
        Assert.AreEqual(typeof(ObjectResult), result.GetType());
        _tableService.Verify(method => method.GetAllByAsync(
            It.IsAny<Expression<Func<TableBase, bool>>>(),
            It.IsAny<CancellationToken>(),
            It.IsAny<Expression<Func<TableBase, object>>[]>()), Times.Once());
    }

    [Test]
    public async Task GetAllRestaurantTable_InputInvalidRestaurantId_ReturnNotNull_ReturnBadRequest_NoScheduleServiceCall()
    {
        //Arrange
        _tableService.Setup(method => method.GetAllByAsync(
                It.IsAny<Expression<Func<TableBase, bool>>>(),
                It.IsAny<CancellationToken>(),
                It.IsAny<Expression<Func<TableBase, object>>[]>()))
            .ReturnsAsync(new Response<TableDto>()).Verifiable();

        //Act
        var result = await _tableController.GetAllRestaurantTable(string.Empty, CancellationToken.None);

        //Arrange
        Assert.NotNull(result);
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
        _tableService.Verify(method => method.GetAllByAsync(
            It.IsAny<Expression<Func<TableBase, bool>>>(),
            It.IsAny<CancellationToken>(),
            It.IsAny<Expression<Func<TableBase, object>>[]>()), Times.Never());
    }

    [Test]
    public async Task GetSingleRestaurantTable_InputValidTableId_ReturnNotNull_ReturnType_ScheduleServiceCall()
    {
        //Arrange
        _tableService.Setup(method => method.GetSingleByAsync(
                It.IsAny<Expression<Func<TableBase, bool>>>(),
                It.IsAny<CancellationToken>(),
                It.IsAny<Expression<Func<TableBase, object>>[]>()))
            .ReturnsAsync(new Response<TableDto>()).Verifiable();
        const string tableId = "id";

        //Act
        var result = await _tableController.GetSingleRestaurantTable(tableId, CancellationToken.None);

        //Arrange
        Assert.NotNull(result);
        Assert.AreEqual(typeof(ObjectResult), result.GetType());
        _tableService.Verify(method => method.GetSingleByAsync(
            It.IsAny<Expression<Func<TableBase, bool>>>(),
            It.IsAny<CancellationToken>(),
            It.IsAny<Expression<Func<TableBase, object>>[]>()), Times.Once());
    }

    [Test]
    public async Task GetSingleRestaurantTable_InputInvalidTableId_ReturnNotNull_ReturnBadRequest_NoScheduleServiceCall()
    {
        //Arrange
        _tableService.Setup(method => method.GetAllByAsync(
                It.IsAny<Expression<Func<TableBase, bool>>>(),
                It.IsAny<CancellationToken>(),
                It.IsAny<Expression<Func<TableBase, object>>[]>()))
            .ReturnsAsync(new Response<TableDto>()).Verifiable();

        //Act
        var result = await _tableController.GetSingleRestaurantTable(string.Empty, CancellationToken.None);

        //Arrange
        Assert.NotNull(result);
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
        _tableService.Verify(method => method.GetAllByAsync(
            It.IsAny<Expression<Func<TableBase, bool>>>(),
            It.IsAny<CancellationToken>(),
            It.IsAny<Expression<Func<TableBase, object>>[]>()), Times.Never());
    }

    [Test]
    public async Task CreateTable_Verify_ReturnNotNull_ReturnType_ScheduleServiceCall()
    {
        //Arrange
        _tableService.Setup(method => method.CreateAsync(
                It.IsAny<TableCreate>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Response<TableDto>()).Verifiable();
        var tableToCreate = new TableCreate();

        //Act
        var result = await _tableController.CreateTable(tableToCreate, CancellationToken.None);

        //Arrange
        Assert.NotNull(result);
        Assert.AreEqual(typeof(ObjectResult), result.GetType());
        _tableService.Verify(method => method.CreateAsync(
            It.IsAny<TableCreate>(),
            It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task CreateTable_InputInvalid_ReturnNotNull_ReturnBadRequest_NoScheduleServiceCall()
    {
        //Arrange
        _tableService.Setup(method => method.CreateAsync(
                It.IsAny<TableCreate>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Response<TableDto>()).Verifiable();
        var tableToCreate = new TableCreate();
        _tableController.ModelState.AddModelError("test", "test");

        //Act
        var result = await _tableController.CreateTable(tableToCreate, CancellationToken.None);

        //Arrange
        Assert.NotNull(result);
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
        _tableService.Verify(method => method.CreateAsync(
            It.IsAny<TableCreate>(),
            It.IsAny<CancellationToken>()), Times.Never);
    }

    [Test]
    public async Task UpdateTable_Verify_ReturnNotNull_ReturnType_ScheduleServiceCall()
    {
        //Arrange
        _tableService.Setup(method => method.UpdateAsync(
                It.IsAny<TableUpdate>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Response<TableDto>()).Verifiable();
        

        //Act
        var result = await _tableController.UpdateTable(new TableUpdate(), CancellationToken.None);

        //Arrange
        Assert.NotNull(result);
        Assert.AreEqual(typeof(ObjectResult), result.GetType());
        _tableService.Verify(method => method.UpdateAsync(
            It.IsAny<TableUpdate>(),
            It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task UpdateTable_InputInvalid_ReturnNotNull_ReturnBadRequest_NoScheduleServiceCall()
    {
        //Arrange
        _tableService.Setup(method => method.UpdateAsync(
                It.IsAny<TableUpdate>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Response<TableDto>()).Verifiable();
        _tableController.ModelState.AddModelError("test", "test");

        //Act
        var result = await _tableController.UpdateTable(new TableUpdate(), CancellationToken.None);

        //Arrange
        Assert.NotNull(result);
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
        _tableService.Verify(method => method.UpdateAsync(
            It.IsAny<TableUpdate>(),
            It.IsAny<CancellationToken>()), Times.Never);
    }

    [Test]
    public async Task DeleteTable_InputValidTableId_ReturnNotNull_ReturnType_ScheduleServiceCall()
    {
        //Arrange
        _tableService.Setup(method => method.DeleteAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Response<TableDto>()).Verifiable();
        const string tableId = "id";

        //Act
        var result = await _tableController.DeleteTable(tableId, CancellationToken.None);

        //Arrange
        Assert.NotNull(result);
        Assert.AreEqual(typeof(ObjectResult), result.GetType());
        _tableService.Verify(method => method.DeleteAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()), Times.Once);
    }

    [Test]
    public async Task DeleteTable_InputInvalidTableId_ReturnNotNull_ReturnBadRequest_NoScheduleServiceCall()
    {
        //Arrange
        _tableService.Setup(method => method.DeleteAsync(
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Response<TableDto>()).Verifiable();

        //Act
        var result = await _tableController.DeleteTable(string.Empty, CancellationToken.None);

        //Arrange
        Assert.NotNull(result);
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
        _tableService.Verify(method => method.DeleteAsync(
            It.IsAny<string>(),
            It.IsAny<CancellationToken>()), Times.Never());
    }

}
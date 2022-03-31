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

}
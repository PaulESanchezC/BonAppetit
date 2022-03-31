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
    public async Task GetSingleRestaurantSchedule_Verify_()
    {

    }



}
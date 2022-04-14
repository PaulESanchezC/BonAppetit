using Microsoft.AspNetCore.Mvc;
using Models.PaymentModels;
using Models.ResponseModels;
using Moq;
using NUnit.Framework;
using PaymentService.Controllers;
using Services.PaymentServices;

namespace Tests;

[TestFixture]
public class PaymentControllerTests
{
    private PaymentController _paymentController;
    private Mock<IPaymentServices> _paymentServices;

    [SetUp]
    public void Setup()
    {
        _paymentServices = new();
        _paymentController = new(_paymentServices.Object);
    }

    [Test]
    public async Task CreatePaymentSession_ValidInput_Verify_ReturnNotNull_ServiceCall()
    {
        //Arrange
        _paymentServices.Setup(method=>method.CreateStripePaymentSessionAsync(
            It.IsAny<PaymentCreate>(),
            It.IsAny<CancellationToken>()
            )).ReturnsAsync(new Response<PaymentDto>()).Verifiable();

        //Act
        var result = await _paymentController.CreatePaymentSession(new PaymentCreate(), CancellationToken.None);

        //Assert
        Assert.NotNull(result);
        Assert.AreEqual(typeof(ObjectResult),result.GetType());
        _paymentServices.Verify((method => method.CreateStripePaymentSessionAsync(
            It.IsAny<PaymentCreate>(),
            It.IsAny<CancellationToken>()
        )),Times.Once());
    }

    [Test]
    public async Task CreatePaymentSession_InvalidInput_Verify_ReturnNotNull_NoServiceCall()
    {
        //Arrange
        _paymentServices.Setup(method => method.CreateStripePaymentSessionAsync(
            It.IsAny<PaymentCreate>(),
            It.IsAny<CancellationToken>()
        )).ReturnsAsync(new Response<PaymentDto>()).Verifiable();
        _paymentController.ModelState.AddModelError("test","test");

        //Act
        var result = await _paymentController.CreatePaymentSession(new PaymentCreate(), CancellationToken.None);

        //Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
        _paymentServices.Verify((method => method.CreateStripePaymentSessionAsync(
            It.IsAny<PaymentCreate>(),
            It.IsAny<CancellationToken>()
        )), Times.Never());
    }

    [Test]
    public async Task ConfirmPayment_ValidInput_Verify_ReturnNotNull_ServiceCall()
    {
        //Arrange
        _paymentServices.Setup(method => method.ConfirmPaymentIsSuccessful(
            It.IsAny<PaymentDto>(),
            It.IsAny<CancellationToken>()
        )).ReturnsAsync(new Response<PaymentDto>()).Verifiable();

        //Act
        var result = await _paymentController.ConfirmPayment(new PaymentDto(), CancellationToken.None);

        //Assert
        Assert.NotNull(result);
        Assert.AreEqual(typeof(ObjectResult), result.GetType());
        _paymentServices.Verify((method => method.ConfirmPaymentIsSuccessful(
            It.IsAny<PaymentDto>(),
            It.IsAny<CancellationToken>()
        )), Times.Once());
    }

    [Test]
    public async Task ConfirmPayment_InvalidInput_Verify_ReturnNotNull_NoServiceCall()
    {
        //Arrange
        _paymentServices.Setup(method => method.ConfirmPaymentIsSuccessful(
            It.IsAny<PaymentDto>(),
            It.IsAny<CancellationToken>()
        )).ReturnsAsync(new Response<PaymentDto>()).Verifiable();
        _paymentController.ModelState.AddModelError("test", "test");

        //Act
        var result = await _paymentController.ConfirmPayment(new PaymentDto(), CancellationToken.None);

        //Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
        _paymentServices.Verify((method => method.ConfirmPaymentIsSuccessful(
            It.IsAny<PaymentDto>(),
            It.IsAny<CancellationToken>()
        )), Times.Never());
    }
}
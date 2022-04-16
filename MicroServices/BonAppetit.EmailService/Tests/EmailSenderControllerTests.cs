using EmailService.Controllers;
using Microsoft.AspNetCore.Mvc;
using Models.EmailModels;
using Models.ResponseModels;
using Moq;
using NUnit.Framework;
using Services.EmailServices;

namespace Tests;

[TestFixture]
public class EmailSenderControllerTests
{
    private EmailSenderController _emailSenderController;
    private Mock<IMailJetEmailSender> _emailSender;

    [SetUp]
    public void Setup()
    {
        _emailSender = new();
        _emailSenderController = new(_emailSender.Object);
    }

    [Test]
    public async Task SendEmail_ValidInput_ReturnNotNull_ServiceCall()
    {
        //Arrange
        _emailSender.Setup(method => method.MailJetMailSenderAsync(
            It.IsAny<List<Email>>(),
            It.IsAny<CancellationToken>()
            )).ReturnsAsync(new Response<Email>()).Verifiable();

        //Act
        var result = await _emailSenderController.SendEmail(new List<Email>(), CancellationToken.None);

        //Assert
        Assert.NotNull(result);
        Assert.AreEqual(typeof(ObjectResult),result.GetType());
        _emailSender.Verify(method => method.MailJetMailSenderAsync(
            It.IsAny<List<Email>>(),
            It.IsAny<CancellationToken>()),Times.Once);
    }

    [Test]
    public async Task SendEmail_InvalidInput_ReturnNotNull_NoServiceCall()
    {
        //Arrange
        _emailSender.Setup(method => method.MailJetMailSenderAsync(
            It.IsAny<List<Email>>(),
            It.IsAny<CancellationToken>()
        )).ReturnsAsync(new Response<Email>()).Verifiable();
        _emailSenderController.ModelState.AddModelError("test","test");

        //Act
        var result = await _emailSenderController.SendEmail(new List<Email>(), CancellationToken.None);

        //Assert
        Assert.IsInstanceOf<BadRequestObjectResult>(result);
        _emailSender.Verify(method => method.MailJetMailSenderAsync(
            It.IsAny<List<Email>>(),
            It.IsAny<CancellationToken>()), Times.Never);
    }

}
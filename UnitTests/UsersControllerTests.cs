using Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Services.DTO;
using Services.Interfaces;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class UsersControllerTests
    {
        [Fact]
        public async Task Authenticate_WithValidUser_ReturnsOk()
        {
            // Arrange
            AuthenticationDTO request = new AuthenticationDTO()
            {
                email = "test@gmail.com",
                password = "12345"
            };

            AuthSuccessDTO response = new AuthSuccessDTO()
            {
                id = 1,
                email = request.email,
                token = "test token"
            };

            var serviceStub = new Mock<IUserService>();
            serviceStub.Setup(service => service.Login(request)).ReturnsAsync(response);

            var controller = new UsersController(serviceStub.Object);

            // Act
            var result = await controller.Authenticate(request);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }
    }
}

using Api.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Services.DTO;
using Services.Interfaces;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests
{
    public class AccountControllerTests
    {
        [Fact]
        public async Task GetAccountBalance_WithAuthenticatedUser_ReturnsOk()
        {
            // Arrange
            var claims = new Claim[]{
                new Claim("Id", "1"),
               new Claim(JwtRegisteredClaimNames.Email, "test@gmail.com")
            };

            ClaimsPrincipal principal = new ClaimsPrincipal(new ClaimsIdentity(claims, "AuthenticationTypes.Federation"));
            AccountBalanceDTO response = new AccountBalanceDTO() { Balance = 1523 };

            var serviceStub = new Mock<IAccountService>();
            var controller = new AccountController(serviceStub.Object);

            var contextMock = new Mock<HttpContext>();
            contextMock.Setup(x => x.User).Returns(principal);
            controller.ControllerContext.HttpContext = contextMock.Object;

            serviceStub.Setup(service => service.GetAccountBalance(principal)).ReturnsAsync(response);

            // Act
            var result = await controller.GetAccountBalance();

            // Assert
            Assert.NotNull(controller.User);
            Assert.IsType<OkObjectResult>(result.Result);

        }

        [Fact]
        public async Task GetAccountTransaction_WithAuthenticatedUser_ReturnsOk()
        {
            // Arrange
            var claims = new Claim[]{
                new Claim("Id", "1"),
               new Claim(JwtRegisteredClaimNames.Email, "test@gmail.com")
            };

            ClaimsPrincipal principal = new ClaimsPrincipal(new ClaimsIdentity(claims, "AuthenticationTypes.Federation"));
            List<AccountTransactionDTO> response = new List<AccountTransactionDTO>();

            var serviceStub = new Mock<IAccountService>();
            var controller = new AccountController(serviceStub.Object);

            var contextMock = new Mock<HttpContext>();
            contextMock.Setup(x => x.User).Returns(principal);
            controller.ControllerContext.HttpContext = contextMock.Object;

            serviceStub.Setup(service => service.GetAccountTransaction(principal)).ReturnsAsync(response);

            // Act
            var result = await controller.GetAccountBalance();

            // Assert
            Assert.NotNull(controller.User);
            Assert.IsType<OkObjectResult>(result.Result);

        }
    }
}

using System.Security.Claims;
using LmsClassLibrary.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Moq;
using MvcApplication.Controllers;
using MvcApplication.Logic;
using MvcApplication.Services;

namespace MvcApplication.IntegrationTests
{
    public class HomeControllerTests
    {
        private readonly Mock<IUniversityStructureService> _serviceMock;
        private readonly HomeController _controller;

        public HomeControllerTests()
        {
            _serviceMock = new Mock<IUniversityStructureService>();
            _controller = new HomeController();
        }

        [Fact]
        public async Task Index_ReturnsViewResult()
        {
            // Arrange
            _serviceMock.Setup(s => s.GetFaculties())
                .ReturnsAsync(Array.Empty<Faculty>());
            _serviceMock.Setup(s => s.GetDepartments())
                .ReturnsAsync(Array.Empty<Department>());
            _serviceMock.Setup(s => s.GetSpecialities())
                .ReturnsAsync(Array.Empty<Speciality>());
            // Act
            var result = await _controller.Index();
            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void UserProfile_ReturnsViewResult_WhenUserIsAuthorized()
        {
            // Arrange
            var user = new ClaimsPrincipal(new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, "testUser"),
                new Claim(ClaimTypes.Role, "User")
            }));
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext {User = user}
            };
            // Act
            var result = _controller.UserProfile();
            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task LoginPost_ReturnsRedirectToLogin_WhenUserNotFound()
        {
            // Arrange
            var dto = new MockUserDto {Login = "test", Password = "wrongPassword"};
            var authServiceMock = new Mock<IAuthenticationService>();
            authServiceMock.Setup(authenticationService => authenticationService.SignInAsync(It.IsAny<HttpContext>(),
                    It.IsAny<string>(),
                    It.IsAny<ClaimsPrincipal>(), It.IsAny<AuthenticationProperties>()))
                .Returns(Task.CompletedTask);
            var httpContextMock = new Mock<HttpContext>();
            httpContextMock.Setup(context => context.RequestServices.GetService(typeof(IAuthenticationService)))
                .Returns(authServiceMock.Object);
            httpContextMock.Setup(context => context.Request.Query["ReturnUrl"]).Returns("/someReturnUrl");
            _controller.ControllerContext = new ControllerContext {HttpContext = httpContextMock.Object};
            SetupUrlHelperMock(_controller);
            // Act
            var result = await _controller.LoginPost(dto);
            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Login", redirectToActionResult.ActionName);
        }

        [Fact]
        public async Task Logout_ReturnsRedirectToIndex()
        {
            // Arrange
            var authServiceMock = new Mock<IAuthenticationService>();
            authServiceMock.Setup(authenticationService =>
                    authenticationService.SignOutAsync(It.IsAny<HttpContext>(), It.IsAny<string>(),
                        It.IsAny<AuthenticationProperties>()))
                .Returns(Task.CompletedTask);
            var httpContextMock = new Mock<HttpContext>();
            httpContextMock.Setup(context => context.RequestServices.GetService(typeof(IAuthenticationService)))
                .Returns(authServiceMock.Object);
            _controller.ControllerContext = new ControllerContext {HttpContext = httpContextMock.Object};
            SetupUrlHelperMock(_controller);
            // Act
            var result = await _controller.Logout();
            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        private static void SetupUrlHelperMock(ControllerBase controller)
        {
            var urlHelperMock = new Mock<IUrlHelper>();
            urlHelperMock.Setup(url => url.IsLocalUrl(It.IsAny<string>())).Returns<string>(url => url == "/localUrl");
            urlHelperMock.Setup(url => url.Action(It.IsAny<UrlActionContext>())).Returns("http://localhost");
            var urlHelperFactoryMock = new Mock<IUrlHelperFactory>();
            urlHelperFactoryMock.Setup(factory => factory.GetUrlHelper(It.IsAny<ActionContext>()))
                .Returns(urlHelperMock.Object);
            controller.Url = urlHelperMock.Object;
        }
    }
}
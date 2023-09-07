using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcApplication.Filters;
using MvcApplication.Logic;
using MvcApplication.Models;
using MvcApplication.Services;

namespace MvcApplication.Controllers;

public class HomeController : Controller
{
    private UniversityStructureService _service;
    public HomeController(UniversityStructureService service) =>
        _service = service;

    [LoggingFilter]
    public IActionResult Index()
    {
        var faculties = _service.GetFaculties();
        var departments = _service.GetDepartments();
        var specialities = _service.GetSpecialities();
        // throw new Exception();
        return View();
    }

    public IActionResult IndexPost(TestUser user)
    {
        var id = user.Id;
        return RedirectToAction("Index");
    }

    [Authorize(Roles = "Admin")]
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
    
    public IActionResult Login() =>
        View(new MockUserDto {ReturnUrl = HttpContext.Request.Query["ReturnUrl"].ToString()});
    
    public async Task<IActionResult> LoginPost(MockUserDto dto)
    {
        var mockUser = AuthMock.Users.FirstOrDefault(user =>
            user.Login == dto.Login && user.Password == dto.Password);
        if (mockUser == null) return RedirectToAction("Login");
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(new ClaimsIdentity(
                new List<Claim>
                {
                    new(ClaimTypes.Name, mockUser.Login),
                    new(ClaimTypes.Role, mockUser.Role)
                }, CookieAuthenticationDefaults.AuthenticationScheme)));
        if (!string.IsNullOrWhiteSpace(dto.ReturnUrl) && Url.IsLocalUrl(dto.ReturnUrl))
            return Redirect(dto.ReturnUrl);
        return RedirectToAction("Index");
    }
    
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index");
    }
}
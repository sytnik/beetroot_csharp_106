using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcApplication.Logic;
using MvcApplication.Models;
using ShopLibrary;

namespace MvcApplication.Controllers;

public class HomeController : Controller
{
    private readonly IShopService _service;
    public HomeController(IShopService service) => _service = service;
    
    public async Task<IActionResult> Index() =>
        View(await _service.GetCustomers());
    
    public async Task<IActionResult> CustomerProfile(int id)=>
        View(await _service.GetCustomer(id));
    
    [Authorize(Roles = "User")]
    public IActionResult UserProfile() => View();

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
        if(!ModelState.IsValid) return View("Login", dto);
        var mockUser = AuthMock.Users.FirstOrDefault(user =>
            user.Login == dto.Login && user.Password == dto.Password);

        if (mockUser == null)
        {
            ModelState.AddModelError("Password", "Invalid login or password");
            return View("Login", dto);
        }
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
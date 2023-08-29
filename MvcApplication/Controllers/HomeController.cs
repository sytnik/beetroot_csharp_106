using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcApplication.Models;

namespace MvcApplication.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // GET: /Home/Index (/Home/)
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Index(IFormCollection form)
    {
        var id = int.Parse(form["id"].ToString());
        var name = form["name"].ToString();
        var date = DateOnly.Parse(form["date"].ToString());
        return RedirectToAction("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}
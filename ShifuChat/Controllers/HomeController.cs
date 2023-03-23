using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ShifuChat.Models;
using ShifuChat.BL.GiveMeUser;

namespace ShifuChat.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IRegesteredUser _isRegesteredUser;

    public HomeController(ILogger<HomeController> logger,IRegesteredUser isRegesteredUser)
    {
        _logger = logger;
        _isRegesteredUser = isRegesteredUser;
    }

    public  IActionResult Index()
    {
        return  View(_isRegesteredUser.IsRegesteredUser());
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


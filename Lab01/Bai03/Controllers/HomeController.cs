using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bai03.Models;

namespace Bai03.Controllers;

public class HomeController : Controller
{
    [Route("/")]
    [HttpGet("/Home/Index")]
    public IActionResult Index()
    {
        return View();
    }
    [HttpGet("/Home/RedirectToGoogle")]
    public IActionResult RedirectToGoogle()
    {
        return Redirect("https://www.google.com");
    }
    [HttpGet("/Home/Demo")]
    public IActionResult Demo()
    {
        TempData["Message"] = "Bạn vừa được chuyển hướng từ Demo1 sang Index bằng RedirectToAction!";
        return RedirectToAction("Demo");
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

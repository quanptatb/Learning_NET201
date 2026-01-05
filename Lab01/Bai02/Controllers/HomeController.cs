using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bai02.Models;
using System.Runtime.Versioning;

namespace Bai02.Controllers;

public class HomeController : Controller
{
    [Route("/")]
    [HttpGet("/Home/Index")]
    public IActionResult Index()
    {
        return View();
    }
    [HttpGet("/Home/ReturnContent")]
    public IActionResult ReturnContext()
    {
        return Content("Hello world.");
    }
    [HttpGet("/Home/ReturnJson")]
    public IActionResult ReturnJson()
    {
        var student = new
        {
            Id = 1,
            Name = "Pham Tran Anh Quan",
            Age = 20
        };
        return Json(student);
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

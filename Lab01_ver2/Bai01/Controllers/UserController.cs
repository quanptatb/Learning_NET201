using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bai01.Models;

namespace Bai01.Controllers;
public class UserController : Controller
{
    private static List<UserModel> user = new List<UserModel>()
    {
        new UserModel(){ UserId = 1, UserName = "anhquan0108", Email = "anhquanpham2008@gmail.com", Password = "123" }
    };
    [HttpGet]
    private IActionResult GetUser()
    {
        return View(user);
    }
}
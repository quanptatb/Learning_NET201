using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bai01.Models;
using Bai01.Data; // Thêm namespace Data

namespace Bai01.Controllers;

public class HomeController : Controller
{
    private readonly CompanyContext _context; // Khai báo context

    // Inject Context qua Constructor
    public HomeController(CompanyContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult CreateInformation()
    {
        var info = new Information()
        {
            Name = "Phan Viet The",
            License = "Thepv",
            Revenue = 1000,
            Established = Convert.ToDateTime("2024/09/02")
        };

        _context.Information.Add(info); // Thêm vào DbSet
        _context.SaveChanges(); // Lưu xuống SQL

        return Content("Đã thêm dữ liệu thành công!");
    }

    // ... (Các action Privacy, Error giữ nguyên)
}
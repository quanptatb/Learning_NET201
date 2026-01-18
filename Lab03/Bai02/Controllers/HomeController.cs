using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bai02.Models;
using Microsoft.EntityFrameworkCore;

namespace Bai02.Controllers;

public class HomeController : Controller
{
    private readonly NET201_Lab03_Bai02Context _context;

    public HomeController(NET201_Lab03_Bai02Context context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        // Lấy danh sách sản phẩm kèm theo Category
        var products = await _context.Products.Include(p => p.Category).ToListAsync();
        return View(products);
    }

    // Action chi tiết sản phẩm
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var product = await _context.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (product == null) return NotFound();

        return View(product);
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

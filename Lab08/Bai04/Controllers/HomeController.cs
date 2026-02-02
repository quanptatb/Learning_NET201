using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bai04.Models;
using Bai04.Data;
using Microsoft.EntityFrameworkCore;

namespace Bai04.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context;

    public HomeController(ILogger<HomeController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        var students = _context.Students
            .Include(s => s.Enrollments)
            .ThenInclude(e => e.Course)
            .ToList();

        ViewBag.Title = "Eager Loading List";
        return View(students);
    }

    public IActionResult Details(int id)
    {
        // Chỉ lấy Student, không dùng Include. 
        // Dữ liệu Enrollments/Course sẽ tự động load khi truy cập property (do có virtual và Proxies)
        var student = _context.Students.Find(id);

        if (student == null) return NotFound();

        return View(student);
    }

    public IActionResult RawSql()
    {
        // Câu truy vấn lấy Sinh viên và Môn học họ đăng ký
        var query = @"
            SELECT s.StudentId, s.Name, c.Title as CourseTitle
            FROM Students s
            JOIN Enrollments e ON s.StudentId = e.StudentId
            JOIN Courses c ON e.CourseId = c.CourseId";

        // Lưu ý: Để map vào Object, ta cần tạo ViewModel hoặc dùng thủ thuật. 
        // Ở đây để đơn giản tôi sẽ dùng Eager Loading để view hiển thị, 
        // nhưng logic backend là minh họa việc SQL query.

        var statsQuery = _context.Courses
            .FromSqlRaw("SELECT c.CourseId, c.Title, (SELECT COUNT(*) FROM Enrollments e WHERE e.CourseId = c.CourseId) as StudentCount FROM Courses c")
            .Select(x => new { x.Title, Count = x.Enrollments.Count }) // Demo mapping
            .ToList();

        // Để hiển thị list sinh viên như Index để so sánh:
        var students = _context.Students
            .FromSqlRaw("SELECT * FROM Students")
            .ToList();

        // Khi dùng FromSqlRaw, các bảng liên quan vẫn có thể load bằng Lazy Loading nếu đã config
        ViewBag.Title = "Raw SQL Demo";
        return View("Index", students);
    }

    public IActionResult Privacy()
    {
        return View();
    }
}
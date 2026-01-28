using Microsoft.AspNetCore.Mvc;
using Lab06.Data;
using Lab06.Models;

namespace Lab06.Controllers
{
    public class StudentController : Controller
    {
        private readonly SchoolContext _context;

        public StudentController(SchoolContext context)
        {
            _context = context;
        }

        // GET: Hiển thị form
        public IActionResult Index()
        {
            return View();
        }

        // POST: Xử lý submit form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
                return Content("Đã thêm sinh viên thành công!"); // Hoặc RedirectToAction
            }
            // Nếu không hợp lệ, trả về view cùng với thông báo lỗi
            return View(student);
        }
    }
}
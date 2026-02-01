using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bai01.Data;
using Bai01.Models;

namespace Bai01.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentContext _context;

        public StudentsController(StudentContext context)
        {
            _context = context;
        }

        // 1. GET: Students (Hiển thị danh sách)
        public async Task<IActionResult> Index()
        {
            // Dùng Native SQL để lấy danh sách
            var students = await _context.Students
                            .FromSqlRaw("SELECT * FROM Students")
                            .ToListAsync();
            return View(students);
        }

        // 2. GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            // Dùng Native SQL lấy 1 sinh viên
            var student = await _context.Students
                            .FromSqlRaw("SELECT * FROM Students WHERE StudentId = {0}", id)
                            .FirstOrDefaultAsync();

            if (student == null) return NotFound();
            return View(student);
        }

        // 3. GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,DateOfBirth,Email")] Student student)
        {
            if (ModelState.IsValid)
            {
                // Dùng Native SQL để INSERT
                string sql = "INSERT INTO Students (FirstName, LastName, DateOfBirth, Email) VALUES ({0}, {1}, {2}, {3})";
                await _context.Database.ExecuteSqlRawAsync(sql, student.FirstName, student.LastName, student.DateOfBirth, student.Email);

                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // 4. GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var student = await _context.Students
                            .FromSqlRaw("SELECT * FROM Students WHERE StudentId = {0}", id)
                            .FirstOrDefaultAsync();
            if (student == null) return NotFound();
            return View(student);
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,FirstName,LastName,DateOfBirth,Email")] Student student)
        {
            if (id != student.StudentId) return NotFound();

            if (ModelState.IsValid)
            {
                // Dùng Native SQL để UPDATE
                string sql = "UPDATE Students SET FirstName = {0}, LastName = {1}, DateOfBirth = {2}, Email = {3} WHERE StudentId = {4}";
                await _context.Database.ExecuteSqlRawAsync(sql, student.FirstName, student.LastName, student.DateOfBirth, student.Email, id);

                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // 5. GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var student = await _context.Students
                            .FromSqlRaw("SELECT * FROM Students WHERE StudentId = {0}", id)
                            .FirstOrDefaultAsync();

            if (student == null) return NotFound();
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Dùng Native SQL để DELETE
            string sql = "DELETE FROM Students WHERE StudentId = {0}";
            await _context.Database.ExecuteSqlRawAsync(sql, id);

            return RedirectToAction(nameof(Index));
        }
    }
}
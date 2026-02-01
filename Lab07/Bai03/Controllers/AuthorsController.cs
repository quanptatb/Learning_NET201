using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bai03.Data;
using Bai03.Models;

namespace Bai03.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly LibraryContext _context;

        public AuthorsController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Authors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Authors.ToListAsync());
        }

        // GET: Authors/Details/5 (Hiển thị sách của tác giả)
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            // Sử dụng Include để lấy kèm danh sách sách (Requirements 4.a.ii.1)
            var author = await _context.Authors
                .Include(a => a.Books)
                .FirstOrDefaultAsync(m => m.AuthorId == id);

            if (author == null) return NotFound();

            return View(author);
        }

        // GET: Authors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AuthorId,AuthorName")] Author author)
        {
            if (ModelState.IsValid)
            {
                _context.Add(author);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // ... (Action Edit tương tự Create) ...

        // GET: Authors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var author = await _context.Authors
                .FirstOrDefaultAsync(m => m.AuthorId == id);
            if (author == null) return NotFound();

            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author != null)
            {
                // Kiểm tra logic: Không cho xóa nếu đã có sách (Requirements 4.a.v.1)
                bool hasBooks = await _context.Books.AnyAsync(b => b.AuthorId == id);
                if (hasBooks)
                {
                    ModelState.AddModelError("", "Không thể xóa tác giả này vì đang có sách trong thư viện.");
                    return View(author);
                }

                _context.Authors.Remove(author);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
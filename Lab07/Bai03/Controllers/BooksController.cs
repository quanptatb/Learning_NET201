using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bai03.Data;
using Bai03.Models;

namespace Bai03.Controllers
{
    public class BooksController : Controller
    {
        private readonly LibraryContext _context;

        public BooksController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            // Include Author để hiển thị tên tác giả thay vì ID
            var libraryContext = _context.Books.Include(b => b.Author);
            return View(await libraryContext.ToListAsync());
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            // Tạo Dropdown list (Requirements 3.a.iii.1)
            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "AuthorName");
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,BookTitle,PublicationYear,AuthorId")] Book book)
        {
            // Bỏ qua validate Author vì nó là navigation property
            ModelState.Remove("Author");

            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "AuthorName", book.AuthorId);
            return View(book);
        }

        // ... Các action Edit/Delete tương tự, nhớ dùng SelectList cho Edit ...
    }
}
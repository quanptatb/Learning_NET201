using Bai02.Data;
using Bai02.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace Bai02.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 1. Hiển thị danh sách đơn hàng (Index - gọi sp_GetOrders) [cite: 84]
        public async Task<IActionResult> Index()
        {
            var orders = await _context.Orders
                .FromSqlRaw("EXEC sp_GetOrders")
                .ToListAsync();
            return View(orders);
        }

        // 2. Xem chi tiết đơn hàng (Details - gọi sp_GetOrderDetails) [cite: 90]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            // Lấy thông tin đơn hàng (có thể query trực tiếp hoặc dùng Find)
            var order = await _context.Orders.FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null) return NotFound();

            // Lấy chi tiết bằng SP
            var details = await _context.OrderDetails
                .FromSqlRaw("EXEC sp_GetOrderDetails @OrderId", new SqlParameter("@OrderId", id))
                .ToListAsync();

            // Gán vào ViewBag hoặc ViewModel để hiển thị
            ViewBag.Details = details;

            return View(order);
        }

        // 3. Thêm đơn hàng mới (Create - gọi sp_CreateOrder) [cite: 91]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateOrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var totalAmount = model.Quantity * model.UnitPrice;

                // Tham số cho Stored Procedure
                var pDate = new SqlParameter("@OrderDate", model.OrderDate);
                var pName = new SqlParameter("@CustomerName", model.CustomerName);
                var pTotal = new SqlParameter("@TotalAmount", totalAmount);
                var pProdId = new SqlParameter("@ProductId", model.ProductId);
                var pProdName = new SqlParameter("@ProductName", model.ProductName);
                var pQuant = new SqlParameter("@Quantity", model.Quantity);
                var pPrice = new SqlParameter("@UnitPrice", model.UnitPrice);

                await _context.Database.ExecuteSqlRawAsync(
                    "EXEC sp_CreateOrder @OrderDate, @CustomerName, @TotalAmount, @ProductId, @ProductName, @Quantity, @UnitPrice",
                    pDate, pName, pTotal, pProdId, pProdName, pQuant, pPrice
                );

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // 4. Xóa đơn hàng (Delete - gọi sp_DeleteOrder) [cite: 92]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var order = await _context.Orders.FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null) return NotFound();
            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_DeleteOrder @OrderId",
                new SqlParameter("@OrderId", id)
            );
            return RedirectToAction(nameof(Index));
        }
    }
}
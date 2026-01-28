using Microsoft.AspNetCore.Mvc;
using Lab06.Services;

namespace Lab06.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILoggingService _loggingService;
        private readonly IEmailService _emailService;

        // Inject 3 dịch vụ vào Constructor
        public UserController(IUserService userService, ILoggingService loggingService, IEmailService emailService)
        {
            _userService = userService;
            _loggingService = loggingService;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            _loggingService.Log("Xem danh sách User");
            var users = _userService.GetUsers();
            return View(users);
        }

        [HttpPost]
        public IActionResult AddUser(string userName)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                // Sử dụng các dịch vụ
                _userService.AddUser(userName);
                _loggingService.Log($"Đã thêm user: {userName}");
                _emailService.SendEmail("admin@fpt.edu.vn", "New User", $"User {userName} has been added.");
            }
            return RedirectToAction("Index");
        }
    }
}
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bai01.Models;
using Bai01.DAL;
using System.Linq;
using System.Text.RegularExpressions; // Cần cho Regex

namespace Bai01.Controllers
{
    public class UserController : Controller
    {
        private readonly UserDAL _userDAL;

        public UserController(UserDAL userdal)
        {
            _userDAL = userdal;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var users = _userDAL.GetAllUsers();
            return View(users);
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(UserModel user)
        {
            _userDAL.CreateUser(user);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("ModifyUser")]
        public IActionResult UpdateUser(int id)
        {
            var user = _userDAL.GetAllUsers().FirstOrDefault(u => u.UserId == id);
            return View(user);
        }

        [HttpPost]
        [ActionName("ModifyUser")]
        public IActionResult UpdateUser(UserModel user)
        {
            _userDAL.UpdateUser(user);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteUser(int id)
        {
            _userDAL.DeleteUser(id);
            return RedirectToAction("Index");
        }

        // ==================================================================
        // Phương thức hỗ trợ: Kiểm tra mật khẩu có đủ mạnh hay không
        // ==================================================================
        [NonAction]
        public bool IsStrongPassword(string password)
        {
            if (string.IsNullOrEmpty(password) || password.Length < 8)
                return false;

            // Quy tắc mạnh: ít nhất 8 ký tự, có chữ hoa, chữ thường, số và ký tự đặc biệt
            var hasUpperCase = Regex.IsMatch(password, @"[A-Z]");
            var hasLowerCase = Regex.IsMatch(password, @"[a-z]");
            var hasDigit = Regex.IsMatch(password, @"[0-9]");
            var hasSpecialChar = Regex.IsMatch(password, @"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            return hasUpperCase && hasLowerCase && hasDigit && hasSpecialChar;
        }
    }
}
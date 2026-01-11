using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using Bai01.DAL;
using Bai01.Models;

namespace Bai01.Controllers
{
    [Route("/Order/")]
    public class OrderController : Controller
    {
        private readonly OrderDAL _orderDAL;
        public OrderController(OrderDAL orderdal)
        {
            _orderDAL = orderdal;
        }
        [HttpGet("Index")]
        public IActionResult Index()
        {
            var orders = _orderDAL.GetAllOrders();
            return View(orders);
        }
        //create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost("Create")]
        public IActionResult Create([FromForm] Order order)
        {
            _orderDAL.CreateOrder(order);
            return RedirectToAction("Index");
        }
        //search
        //sử dụng [FromQuery].
        [HttpGet("Search")]
        public IActionResult Search([FromQuery] OrderFilter filter)
        {
            var orders = _orderDAL.SearchOrders(filter);
            return View("Index", orders);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}
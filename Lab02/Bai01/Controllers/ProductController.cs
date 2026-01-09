using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Bai01.DAL;
using Bai01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bai01.Controllers
{
    [Route("/Product/")]
    public class ProductController : Controller
    {
        private readonly ProductDAL _productDAL;

        public ProductController(ProductDAL productdal)
        {
            _productDAL = productdal;
        }
        [HttpGet("Index")]
        public IActionResult Index()
        {
            var products = _productDAL.GetAllProducts();
            return View(products);
        }
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost("Create")]
        public IActionResult Create(Product product)
        {
            _productDAL.CreateProduct(product);
            return RedirectToAction("Index");
        }
        [HttpGet("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var product = _productDAL.GetAllProducts().FirstOrDefault(p => p.Id == id);
            return View(product);
        }
        [HttpPost("Edit/{id}")]
        public IActionResult Edit(Product product)
        {
            _productDAL.UpdateProduct(product);
            return RedirectToAction("Index");
        }
        [HttpGet("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _productDAL.DeleteProduct(id);
            return RedirectToAction("Index");
        }
        [HttpGet("Search")]
        public async Task<IActionResult> Search([FromQuery] ProductSearch model)
        {
            var products = await _productDAL.SearchProducts(model);
            return View("Index", products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}
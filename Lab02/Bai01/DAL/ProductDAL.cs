using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bai01.Models;
using Microsoft.EntityFrameworkCore;

namespace Bai01.DAL
{
    public class ProductDAL
    {
        private readonly AppDbContext _context;
        public ProductDAL(AppDbContext context)
        {
            _context = context;
        }
        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }
        //create
        public void CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        //update
        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
        //delete
        public void DeleteProduct(int productId)
        {
            var product = _context.Products.Find(productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
        //search by Name, MinPrice and MaxPrice.
        //sử dụng [FromQuery].
        public async Task<List<Product>> SearchProducts(ProductSearch model)
        {
            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(model.Name))
            {
                query = query.Where(p => p.Name.Contains(model.Name));
            }
            if (model.MinPrice.HasValue)
            {
                query = query.Where(p => p.Price >= model.MinPrice.Value);
            }
            if (model.MaxPrice.HasValue)
            {
                query = query.Where(p => p.Price <= model.MaxPrice.Value);
            }

            return await query.ToListAsync();
        }
    }
}
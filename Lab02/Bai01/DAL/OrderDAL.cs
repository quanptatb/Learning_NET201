using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bai01.Models;
using Microsoft.EntityFrameworkCore;

namespace Bai01.DAL
{
    public class OrderDAL
    {
        private readonly AppDbContext _context;
        public OrderDAL(AppDbContext context)
        {
            _context = context;
        }
        //get all orders
        public List<Order> GetAllOrders()
        {
            return _context.Orders
                .Include(o => o.OrderDetails)
                .ToList();
        }
        //create order with order details
        public void CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        //search by StartDate, EndDate, và Status.
        //sử dụng [FromQuery].
        public List<Order> SearchOrders(OrderFilter filter)
        {
            var query = _context.Orders.AsQueryable();

            if (filter.StartDate.HasValue)
            {
                query = query.Where(o => o.OrderDate >= filter.StartDate.Value);
            }
            if (filter.EndDate.HasValue)
            {
                query = query.Where(o => o.OrderDate <= filter.EndDate.Value);
            }
            if (!string.IsNullOrEmpty(filter.Status))
            {
                query = query.Where(o => o.Status == filter.Status);
            }

            return query.ToList();
        }
    }
}
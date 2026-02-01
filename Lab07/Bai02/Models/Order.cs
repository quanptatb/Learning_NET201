using System.ComponentModel.DataAnnotations;

namespace Bai02.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }

        // Thuộc tính điều hướng (nếu cần dùng trong View, nhưng Bài 2 chủ yếu dùng SP)
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
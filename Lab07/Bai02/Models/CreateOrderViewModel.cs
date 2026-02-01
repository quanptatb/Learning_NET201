namespace Bai02.Models
{
    public class CreateOrderViewModel
    {
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public string CustomerName { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        // TotalAmount sẽ được tính toán: Quantity * UnitPrice
    }
}
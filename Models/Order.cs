namespace OrderApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }  // 主キー
        public string CustomerName { get; set; } = string.Empty;

        public int CustomerId { get; set; }


        public List<OrderDetail> OrderDetails { get; set; } = new();
    }
}

namespace OrderApp.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }  // 主キー
        public int OrderId { get; set; }  // 外部キー
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }

        public Order Order { get; set; } = null!;
    }
}

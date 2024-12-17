using Microsoft.EntityFrameworkCore;
using OrderApp.Data;
using OrderApp.Models;

class Program
{
    static void Main()
    {
        using var context = new OrderDbContext();

        // データ追加
        var order = new Order
        {
            CustomerName = "John Doe",
            OrderDetails = new List<OrderDetail>
            {
                new OrderDetail { ProductName = "Apple", Quantity = 5 },
                new OrderDetail { ProductName = "Banana", Quantity = 3 }
            }
        };

        context.Orders.Add(order);
        context.SaveChanges();

        // データ確認
        var savedOrders = context.Orders
            .Include(o => o.OrderDetails)
            .ToList();

        foreach (var o in savedOrders)
        {
            Console.WriteLine($"Order ID: {o.Id}, Customer: {o.CustomerName}");
            foreach (var detail in o.OrderDetails)
            {
                Console.WriteLine($" - Product: {detail.ProductName}, Quantity: {detail.Quantity}");
            }
        }
    }
}

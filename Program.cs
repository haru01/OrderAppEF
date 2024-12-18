using Microsoft.EntityFrameworkCore;
using OrderApp.Data;
using OrderApp.Models;

class Program
{
    static void Main()
    {
        using var context = new OrderDbContext();

        // データ削除
        context.Orders.RemoveRange(context.Orders);
        context.SaveChanges();
        PrintOrders(context);
        //
        Console.WriteLine("== Orderデータ新規追加 ===============");
        Console.WriteLine("=====================================");
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
        PrintOrders(context);

        // OrderDetailsを新たにデータ追加
        Console.WriteLine("== OrderDetailsを新たにデータ追加 ===============");
        Console.WriteLine("====================================================");
        var order2 = context.Orders
            .Include(o => o.OrderDetails)
            .FirstOrDefault();
        order2?.OrderDetails.Add(new OrderDetail { ProductName = "Cherry", Quantity = 10 });
        context.SaveChanges();
        PrintOrders(context);

        // OrderDetailsのプロパティを更新
        Console.WriteLine("== 特定のOrderDetailsのプロパティを更新 ===============");
        Console.WriteLine("====================================================");
        var order3 = context.Orders
            .Include(o => o.OrderDetails)
            .FirstOrDefault();
        var detail = order3?.OrderDetails.FirstOrDefault(od => od.ProductName == "Apple");
        if (detail != null)
        {
            detail.Quantity = 2000;
        }
        context.SaveChanges();
        PrintOrders(context);

        // OrderDetailsの一部を削除
        Console.WriteLine("== OrderDetailsの一部を削除 ===================================");
        Console.WriteLine("====================================================");
        var order4 = context.Orders
            .Include(o => o.OrderDetails)
            .FirstOrDefault();
        var detail2 = order3?.OrderDetails.FirstOrDefault();
        if (detail2 != null)
        {
            order4?.OrderDetails.Remove(detail2);
        }
        context.SaveChanges();
        PrintOrders(context);
    }

    public static void PrintOrders(OrderDbContext context)
    {
        Console.WriteLine("Print Orders ====");
        var orders = context.Orders
            .Include(o => o.OrderDetails)
            .ToList();

        foreach (var o in orders)
        {
            Console.WriteLine($"Order ID: {o.OrderId}, Customer: {o.CustomerName}");
            foreach (var detail in o.OrderDetails)
            {
                Console.WriteLine($" - Product: {detail.ProductName}, Quantity: {detail.Quantity}, detailsID: {detail.OrderDetailId}");
            }
        }
    }
}

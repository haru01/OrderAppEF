using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OrderApp.Models;

namespace OrderApp.Data
{
    public class OrderDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
            optionsBuilder.UseSqlite("Data Source=orderapp.db");
        }
    }
}

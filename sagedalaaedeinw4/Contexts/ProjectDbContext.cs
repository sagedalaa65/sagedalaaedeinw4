using Microsoft.EntityFrameworkCore;
using sagedalaaedeinw4.Models.entities;

namespace sagedalaaedeinw4.Contexts
{
    public class ProjectDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LEVASCH-STD013\\SQLEXPRESS;Database=sagedalaaw4;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItem> orderItems { get; set; }

    }
}

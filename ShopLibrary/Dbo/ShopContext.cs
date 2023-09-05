using Microsoft.EntityFrameworkCore;

namespace ShopLibrary.Dbo;

public class ShopContext : DbContext
{
    public DbSet<Customer> Customer { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<Shop> Shop { get; set; }
    public DbSet<OrderProduct> OrderProduct { get; set; }

    public ShopContext(DbContextOptions<ShopContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Order>()
            .HasMany(order => order.Products)
            .WithMany(product => product.Orders)
            .UsingEntity<OrderProduct>(
                // typeBuilder =>
                // typeBuilder.HasKey(orderProduct =>
                //     new {orderProduct.OrdersId, orderProduct.ProductsId})
                );
    }
}
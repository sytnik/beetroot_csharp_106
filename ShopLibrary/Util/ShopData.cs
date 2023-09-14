using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopLibrary.Dbo;

namespace ShopLibrary.Util;

public static class ShopData
{
    public static void Publish(this ShopContext context)
    {
        var shopFaker = new Faker<Shop>()
            .RuleFor(shop => shop.Id, faker => faker.IndexFaker + 1)
            .RuleFor(shop => shop.Name, faker => faker.Company.CompanyName())
            .RuleFor(shop => shop.Address, faker => faker.Address.FullAddress());
        var shops = shopFaker.Generate(10);
        context.Shop.AddRange(shops);
        var productFaker = new Faker<Product>()
            .RuleFor(product => product.Id, faker => faker.IndexFaker + 1)
            .RuleFor(product => product.Name, faker => faker.Commerce.ProductName())
            .RuleFor(product => product.Price, faker => faker.Random.Decimal(20, 1000))
            .RuleFor(product => product.ShopId, faker => faker.PickRandom(shops).Id);
        var products = productFaker.Generate(200);
        context.Product.AddRange(products);
        var customerFaker = new Faker<Customer>()
            .RuleFor(customer => customer.Id, faker => faker.IndexFaker + 1)
            .RuleFor(customer => customer.Name, faker => faker.Name.FullName())
            .RuleFor(customer => customer.Address, faker => faker.Address.FullAddress());
        var customers = customerFaker.Generate(50);
        context.Customer.AddRange(customers);
        var orderFaker = new Faker<Order>()
            .RuleFor(order => order.Id, faker => faker.IndexFaker + 1)
            .RuleFor(order => order.CustomerId, faker => faker.PickRandom(customers).Id)
            .RuleFor(order => order.Date, faker => faker.Date.Past());
        var orders = orderFaker.Generate(100);
        context.Order.AddRange(orders);
        var orderProductFaker = new Faker<OrderProduct>()
            .RuleFor(orderProduct => orderProduct.OrderId, faker => faker.PickRandom(orders).Id)
            .RuleFor(orderProduct => orderProduct.ProductId, faker => faker.PickRandom(products).Id)
            .RuleFor(orderProduct => orderProduct.Quantity, faker => faker.Random.Int(1, 10));
        var orderProducts = orderProductFaker.Generate(150)
            .DistinctBy(product => new {OrdersId = product.OrderId, product.ProductId}).ToList();
        context.OrderProduct.AddRange(orderProducts);
        context.SaveChanges();
    }

    public static void AddShopContext(this IServiceCollection services) =>
        services.AddDbContext<ShopContext>(options =>
            options.UseInMemoryDatabase("ShopDb"));
}
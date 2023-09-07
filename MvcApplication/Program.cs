using LmsClassLibrary.Util;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MvcApplication.Logic;
using MvcApplication.Services;
using ShopLibrary.Dbo;
using ShopLibrary.Util;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddShopContext();
builder.Services.AddScoped<UniversityStructureService>();
builder.Services.RegisterContext(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services
    .AddAuthentication(options =>
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => options.LoginPath = "/Home/Login");
var application = builder.Build();
if (application.Environment.IsDevelopment()) application.UseDeveloperExceptionPage();
else if (application.Environment.IsProduction()) application.UseExceptionHandler("/Home/Error");
application.UseHsts();
application.UseHttpsRedirection();
application.UseStaticFiles();
application.UseRouting();
application.UseAuthentication();
application.UseAuthorization();
application.UseSwagger();
application.UseSwaggerUI();
// application.MapControllerRoute(
//     name: "default",
//     pattern: "{controller=Home}/{action=Index}/{id?}");
application.MapDefaultControllerRoute();
// var shopContext = application.Services.CreateScope()
//     .ServiceProvider.GetService<ShopContext>();
// shopContext?.Publish();
// var shops = shopContext?.Shop.ToList();
// var customers2 = shopContext?.Customer.ToList();
// var products = shopContext?.Product.ToList();
// var orders = shopContext?.Order.ToList();
var customers = new List<Customer>
{
    new Customer(1, "John"),
    new Customer(2, "Mary"),
    new Customer(3, "Peter")
};

application.MapGet("/customers", () => customers);

application.MapGet("/customers/{id:int}", (int id) => customers
    .FirstOrDefault(customer => customer.id == id));

application.MapPost("/customers", (Customer customer) =>
{
    customers.Add(customer);
    return customer;
});

application.MapPut("/customers/{id:int}", (int id, Customer customer) =>
{
    var index = customers
        .FindIndex(cust => cust.id == id);
    customers[index] = customer;
    return customer;
});

application.MapDelete("/customers/{id:int}", (int id) =>
{
    var customer = customers
        .FirstOrDefault(cust => cust.id == id);
    if (customer is not null)
        customers.Remove(customer);
});

application.Run();

public record Customer(int id, string Name);
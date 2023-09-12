using LmsClassLibrary.Util;
using Microsoft.AspNetCore.Authentication.Cookies;
using MvcApplication.Services;
using ShopLibrary.Util;

namespace MvcApplication;

public sealed class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddShopContext();
        builder.Services.AddScoped<IUniversityStructureService, UniversityStructureService>();
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
        application.MapDefaultControllerRoute();
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
    }
}

public record Customer(int id, string Name);

// namespace MvcApplication
// {
//     public partial class Program
//     {
//         
//     }
// }
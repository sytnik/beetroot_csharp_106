using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MvcApplication.Logic;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EposContext>(optionsBuilder =>
    optionsBuilder.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services
    .AddAuthentication(options =>
        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => options.LoginPath = "/Home/Login");
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
var customers = new List<Customer>
{
    new Customer(1, "John"),
    new Customer(2, "Mary"),
    new Customer(3, "Peter")
};

app.MapGet("/customers", () => customers);

app.MapGet("/customers/{id:int}", (int id) => customers
    .FirstOrDefault(customer => customer.id == id));

app.MapPost("/customers", (Customer customer) =>
{
    customers.Add(customer);
    return customer;
});

app.MapPut("/customers/{id:int}", (int id, Customer customer) =>
{
    var index = customers
        .FindIndex(cust => cust.id == id);
    customers[index] = customer;
    return customer;
});

app.MapDelete("/customers/{id:int}", (int id) =>
{
    var customer = customers
        .FirstOrDefault(cust => cust.id == id);
    if (customer is not null)
        customers.Remove(customer);
});

app.Run();

public record Customer(int id, string Name);